// Obtenir le bouton de changement de thème
const toggleButton = document.getElementById('theme-toggle');

// Ajouter un gestionnaire d'événements pour le bouton de changement de thème
toggleButton.addEventListener('click', () => {
    document.body.classList.toggle('light');
    if (document.body.classList.contains('light')) {
        toggleButton.innerHTML = '<i class="fas fa-sun"></i> Light Mode <i class="fas fa-sun"></i>';
    } else {
        toggleButton.innerHTML = '<i class="fas fa-moon"></i> Dark Mode <i class="fas fa-moon"></i>';
    }
});

// Créer un nouveau titre h2 pour la section game-results
let H2GR = document.getElementsByClassName('game-results2')[0];
let gameResults = document.createElement("h2");
gameResults.innerHTML = "Résultats du jeu";
H2GR.appendChild(gameResults);

// Obtenir les éléments
const inputField = document.getElementById("game-code");
const submitButton = document.getElementById("submit");

// Créer des variables pour stocker le code entré et les données des joueurs
let gameCode = "";
let lienSite_mod = "";
let playersData = [];

// Définir les liens pour les différentes API
let players_lien = "/players";
let rounds_lien = "/rounds/";
let finalScore_lien = "/final-result";
let parameters_lien = "/parameters";

let lienSite_principal = "http://yams.iutrs.unistra.fr:3000/api/games/";

// Ajouter un gestionnaire d'événements pour le bouton submit
submitButton.addEventListener("click", function(event) {
    event.preventDefault();

    // Stocker la valeur du champ de texte dans une variable
    gameCode = inputField.value;
    lienSite_mod = lienSite_principal + gameCode;

    // Obtenir les données des joueurs
    fetch(lienSite_mod + players_lien)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            playersData = data;

            // Obtenir les données du score final
            return fetch(lienSite_mod + finalScore_lien)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok ' + response.statusText);
                    }
                    return response.json();
                })
                .then(data => {
                    let section = document.querySelector('.game-results2');
                    section.innerHTML = '';

                    let highestScore = 0;
                    let highestScoringPlayer = 'Unknown';

                    // Trouver le joueur avec le score le plus élevé
                    data.forEach(player => {
                        const playerData = playersData.find(p => p.id === player.id_player);
                        let pseudo = 'Unknown';
                        if (playerData && playerData.pseudo) {
                            pseudo = playerData.pseudo;
                        }
                        if (player.score > highestScore) {
                            highestScore = player.score;
                            highestScoringPlayer = pseudo;
                        }
                    });

                    // Afficher le joueur avec le score le plus élevé
                    section.innerHTML += `
                        <div class="highest_score">
                            <p class="winner">Joueur ayant obtenu le meilleur score: ${highestScoringPlayer}</p>
                        </div>
                    `;

                    // Afficher les résultats finaux pour chaque joueur
                    data.forEach(player => {
                        const playerData = playersData.find(p => p.id === player.id_player);
                        let pseudo = 'Unknown';
                        if (playerData && playerData.pseudo) {
                            pseudo = playerData.pseudo;
                        }

                        section.innerHTML += `
                        <div class="final-results">
                            <p>Joueur: ${pseudo}<br>Score final: ${player.score}<br>Bonus: ${player.bonus}</p>
                        </div>
                        `;
                    });
                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });
        })
        .then(() => {
            // Obtenir les données pour tous les tours
            let promise = Promise.resolve();
            for (let roundIndex = 1; roundIndex <= 13; roundIndex++) {
                promise = promise.then(() => {
                    return fetch(`${lienSite_mod}${rounds_lien}${roundIndex}`)
                        .then(response => {
                            if (!response.ok) {
                                throw new Error('Network response was not ok ' + response.statusText);
                            }
                            return response.json();
                        })
                        .then(roundData => {
                            let section = document.querySelector('.game-results2');

                            let roundBlock = document.createElement('div');
                            roundBlock.classList.add('round-block');

                            roundBlock.innerHTML += `<p class="roundId">Tour: ${roundData.id}</p>`;

                            roundData.results.forEach(result => {
                                const player = playersData.find(player => player.id === result.id_player);
                                let pseudo = 'Unknown';
                                if (player && player.pseudo) {
                                    pseudo = player.pseudo;
                                }
                                // Renommer les challenges
                                if (result.challenge == "nombre1") {
                                    result.challenge = "Nombre de 1";
                                } else if (result.challenge == "nombre2") {
                                    result.challenge = "Nombre de 2";
                                } else if (result.challenge == "nombre3") {
                                    result.challenge = "Nombre de 3";
                                } else if (result.challenge == "nombre4") {
                                    result.challenge = "Nombre de 4";
                                } else if (result.challenge == "nombre5") {
                                    result.challenge = "Nombre de 5";
                                } else if (result.challenge == "nombre6") {
                                    result.challenge = "Nombre de 6";
                                } else if (result.challenge == "brelan") {
                                    result.challenge = "Brelan";
                                } else if (result.challenge == "carre") {
                                    result.challenge = "Carré";
                                } else if (result.challenge == "full") {
                                    result.challenge = "Full";
                                } else if (result.challenge == "petite") {
                                    result.challenge = "Petite suite";
                                } else if (result.challenge == "grande") {
                                    result.challenge = "Grande suite";
                                } else if (result.challenge == "yams") {
                                    result.challenge = "Yam's";
                                } else if (result.challenge == "chance") {
                                    result.challenge = "Chance";
                                }

                                roundBlock.innerHTML += `
                                <div class="players">
                                    <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                                    <p>Dice: ${result.dice.join(', ')}</p>
                                    <p>Challenge: ${result.challenge}</p>
                                </div>
                                `;
                            });

                            section.appendChild(roundBlock);
                        })
                        .catch(error => {
                            console.error('There was a problem with the fetch operation:', error);
                        });
                });
            }

            return promise;
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });

    // Obtenir les données des paramètres
    fetch(lienSite_mod + parameters_lien)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
});