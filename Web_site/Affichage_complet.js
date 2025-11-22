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

// Créer un nouvel élément h3 pour prev-turn
let H3PT = document.getElementsByClassName('prev-turn')[0];
let prevTurn = document.createElement("h3");
prevTurn.innerHTML = "Tour précédent";
H3PT.appendChild(prevTurn);

// Créer un nouvel élément h3 pour curr-turn
let H3CT = document.getElementsByClassName('curr-turn')[0];
let currTurn = document.createElement("h3");
currTurn.innerHTML = "Tour actuel";
H3CT.appendChild(currTurn);

// Créer un nouvel élément h3 pour next-turn
let H3TP = document.getElementsByClassName('next-turn')[0];
let nextTurn = document.createElement("h3");
nextTurn.innerHTML = "Tour suivant";
H3TP.appendChild(nextTurn);

// Créer un nouveau titre h2 pour la section game-results
let H2GR = document.getElementsByClassName('game-results')[0];
let gameResults = document.createElement("h2");
gameResults.innerHTML = "Résultats du jeu";
H2GR.appendChild(gameResults);

// Obtenir les éléments
const inputField = document.getElementById("game-code");
const submitButton = document.getElementById("submit");
const prevTurnButton = document.querySelector('.prev-turn');
const nextTurnButton = document.querySelector('.next-turn');

// Créer une variable pour stocker le code entré
let gameCode = "";
let lienSite_mod = "";
let playersData = [];

// Fonction pour créer des images de dés
function createDiceImages(diceArray) {
    return diceArray.map(diceNumber => `<img src="img/dice${diceNumber}.png" alt="Dice ${diceNumber}" style="width: 30px; height: 30px;">`).join(' ');
}

// Définir les liens pour les différentes API
let players_lien = "/players";
let rounds_lien = "/rounds/";
let roundIndex_lien = 1;
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

            // Obtenir les données pour le tour actuel
            fetch(`${lienSite_mod}${rounds_lien}${roundIndex_lien}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok ' + response.statusText);
                    }
                    return response.json();
                })
                .then(roundData => {
                    let section = document.querySelector('.curr-turn');
                    section.innerHTML = '';
                    section.innerHTML += `<p class ="roundId">Tour: ${roundData.id}</p>`;
                    roundData.results.forEach(result => {
                        const player = playersData.find(player => player.id === result.id_player);
                        let pseudo = 'Unknown';
                        if (player && player.pseudo) {
                            pseudo = player.pseudo;
                        }
                        const diceImages = createDiceImages(result.dice);
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
                        section.innerHTML += `
                            <div class="players">
                                <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                                <p>Dice: ${diceImages}</p>
                                <p>Challenge: ${result.challenge}</p>
                            </div>
                        `;
                    });
                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });

            // Obtenir les données pour le tour précédent
            if (roundIndex_lien > 1) {
                fetch(`${lienSite_mod}${rounds_lien}${roundIndex_lien - 1}`)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok ' + response.statusText);
                        }
                        return response.json();
                    })
                    .then(roundData => {
                        let section = document.querySelector('.prev-turn');
                        section.innerHTML = '';
                        section.innerHTML += `<p class ="roundId">Tour: ${roundData.id}</p>`;
                        roundData.results.forEach(result => {
                            const player = playersData.find(player => player.id === result.id_player);
                            let pseudo = 'Unknown';
                            if (player && player.pseudo) {
                                pseudo = player.pseudo;
                            }
                            section.innerHTML += `
                                <div class="players">
                                    <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                                </div>
                            `;
                        });
                    })
                    .catch(error => {
                        console.error('There was a problem with the fetch operation:', error);
                    });
            } else {
                document.querySelector('.prev-turn').innerHTML = "<p>Il n'y a pas de tour précédent</p>";
            }

            // Obtenir les données pour le prochain tour
            if (roundIndex_lien < 13) {
                fetch(`${lienSite_mod}${rounds_lien}${roundIndex_lien + 1}`)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok ' + response.statusText);
                        }
                        return response.json();
                    })
                    .then(roundData => {
                        let section = document.querySelector('.next-turn');
                        section.innerHTML = '';
                        section.innerHTML += `<p class ="roundId">Tour: ${roundData.id}</p>`;
                        roundData.results.forEach(result => {
                            const player = playersData.find(player => player.id === result.id_player);
                            let pseudo = 'Unknown';
                            if (player && player.pseudo) {
                                pseudo = player.pseudo;
                            }
                            section.innerHTML += `
                                <div class="players">
                                    <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                                </div>
                            `;
                        });
                    })
                    .catch(error => {
                        console.error('There was a problem with the fetch operation:', error);
                    });
            } else {
                document.querySelector('.next-turn').innerHTML = "<p>Il n'y a pas de tour suivant</p>";
            }
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });

    // Obtenir les données du score final
    fetch(lienSite_mod + finalScore_lien)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            let final_result = document.querySelector('.game-results');
            final_result.innerHTML = '';

            let highestScore = 0;
            let highestScoringPlayer = 'Unknown';

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

            final_result.innerHTML += `
                <div class="highest_score">
                    <p class="winner">Joueur ayant obtenu le meilleur score: ${highestScoringPlayer}</p>
                </div>
            `;

            data.forEach(player => {
                const playerData = playersData.find(p => p.id === player.id_player);
                let pseudo = 'Unknown';
                if (playerData && playerData.pseudo) {
                    pseudo = playerData.pseudo;
                }
                final_result.innerHTML += `
                    <div class="final_results">
                        <p>Joueur: ${pseudo}<br>Score: ${player.score}<br>Bonus: ${player.bonus}</p>
                    </div>
                `;
            });
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

// Fonction pour obtenir les données du tour
const fetchRoundData = (roundIndex, sectionClass) => {
    fetch(`${lienSite_mod}${rounds_lien}${roundIndex}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(roundData => {
            let section = document.querySelector(sectionClass);
            section.innerHTML = '';
            section.innerHTML += `<p class ="roundId">Tour: ${roundData.id}</p>`;
            roundData.results.forEach(result => {
                const player = playersData.find(player => player.id === result.id_player);
                let pseudo = 'Unknown';
                if (player && player.pseudo) {
                    pseudo = player.pseudo;
                }
                const diceImages = createDiceImages(result.dice);
                // Renommer les challenges
                if (sectionClass === '.curr-turn') {
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
                    section.innerHTML += `
                        <div class="players">
                            <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                            <p>Dice: ${diceImages}</p>
                            <p>Challenge: ${result.challenge}</p>
                        </div>
                    `;
                } else {
                    section.innerHTML += `
                        <div class="players">
                            <p>Joueur: ${pseudo}<br>Score: ${result.score}</p>
                        </div>
                    `;
                }
            });
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
};

// Ajouter des gestionnaires d'événements pour les boutons prev-turn et next-turn
prevTurnButton.addEventListener("click", function() {
    if (roundIndex_lien > 1) {
        roundIndex_lien--;
        fetchRoundData(roundIndex_lien, '.curr-turn');
        if (roundIndex_lien > 1) {
            fetchRoundData(roundIndex_lien - 1, '.prev-turn');
        } else {
            document.querySelector('.prev-turn').innerHTML = "<p>Il n'y a pas de tour précédent</p>";
        }
        if (roundIndex_lien < 13) {
            fetchRoundData(roundIndex_lien + 1, '.next-turn');
        } else {
            document.querySelector('.next-turn').innerHTML = "<p>Il n'y a pas de tour suivant</p>";
        }
    } else {
        document.querySelector('.prev-turn').innerHTML = "<p>Il n'y a pas de tour précédent</p>";
    }
});

nextTurnButton.addEventListener("click", function() {
    if (roundIndex_lien < 13) {
        roundIndex_lien++;
        fetchRoundData(roundIndex_lien, '.curr-turn');
        if (roundIndex_lien > 1) {
            fetchRoundData(roundIndex_lien - 1, '.prev-turn');
        } else {
            document.querySelector('.prev-turn').innerHTML = "<p>Il n'y a pas de tour précédent</p>";
        }
        if (roundIndex_lien < 13) {
            fetchRoundData(roundIndex_lien + 1, '.next-turn');
        } else {
            document.querySelector('.next-turn').innerHTML = "<p>Il n'y a pas de tour suivant</p>";
        }
    } else {
        document.querySelector('.next-turn').innerHTML = "<p>Il n'y a pas de tour suivant</p>";
    }
});