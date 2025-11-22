using System;
using System.IO;
using System.Text;
public struct joueurs{
	public string pseudo;
	public int score;
	public int scoremineur;
	public int id;
	public int bonus;
}
public struct rounds{
	public int [] diceP1;
	public int challengeP1;
	public int scoreP1;
	public int [] diceP2;
	public int challengeP2;
	public int scoreP2;
}
public struct asciiArt {
	public string L1;
	public string L2;
	public string L3;
	public string L4;
	public string L5;
	public string L6;
	public string L7;
}
class yams
{
	public static int rolldice(){//attribution de la valeur alléatoire pour les dés
		Random rnd = new Random();
    	int R = rnd.Next(1, 7);
    	return R;
    }


    public static int [] lancer(bool []alancer,int []result){ //lancé de dé (atttribution d'une valeur alléatoire (entre 1 et 6) aux dés désigné pour être lancé ou relancés )
    	int R=0;
    	for (int i=0;i<5;i++){
    		if (alancer[i]==true){
    			R=rolldice();
    			result[i]=R;
    		}
    	}
    	return result;
    }


    public static bool [] select_relance (int [] result){//Choix de relancer ou non un dé
    	bool [] relance=new bool [5];
    	string choix=" ";
    	for (int i = 0;i<5;i++){
  			choix=" ";
    		while(choix!="o" && choix!="n"){
	    		Console.Write($"relancer le dé {i+1} ([{result[i]}]) ? (o/n) :");
    			choix=Console.ReadLine();
    		}
    		if (choix =="o"){
    			relance[i]=true;
    		}
    		else {
    			relance[i]=false;
    		}
 		}
    	return relance;
    }

	public static int[] tourparjoueur(){//choix de relancer les dés ou non, appelle des fonctions précédantes et celle de l'affichage des dés
		int [] result= new int [5] {0,0,0,0,0};
		bool [] NbLancer=new bool [5]{true,true,true,true,true};
		result=lancer(NbLancer,result);
		string dices="";
		for (int i=0;i<5;i++){
			dices= dices+result[i].ToString();
 	    }
	        	affichedice(dices);
	    int jet=0;
	    string choixall;
		choixall=" ";
	    while (jet<2 && choixall != "n"){
		    choixall=" ";
		    while(choixall!="o" && choixall!="n"){
		   		Console.WriteLine();
		    	Console.Write("Voulez vous relancer des dés ? (o/n) :");
		    	choixall=Console.ReadLine();
		    }
	    	if (choixall =="o"){
	    	   	Console.WriteLine();
				NbLancer=select_relance(result);
				result=lancer(NbLancer,result);
				Console.Write("\n");
				dices="";
				for (int i=0;i<5;i++){
		        	dices= dices+result[i].ToString();
	  	    	}
	        	affichedice(dices);
	  	    }
	  	    jet++;
	 	}
		Console.WriteLine();
		return result;
	}

		public static void affichedice(string input){ // utilise la structure asciiArt pour y enregistrer chaques lignes de chaques dés et ensuite y lire les dés en enregistrant la suite de dés ligne par ligne puis en affichant les lignes les unes après les autres.
		asciiArt D1=new asciiArt();
		asciiArt D2=new asciiArt();
		asciiArt D3=new asciiArt();
		asciiArt D4=new asciiArt();
		asciiArt D5=new asciiArt();
		asciiArt D6=new asciiArt();

		D1.L1="████████████";
		D1.L2="█          █";
		D1.L3="█          █";
		D1.L4="█    ██    █";
		D1.L5="█          █";
		D1.L6="█          █";
		D1.L7="████████████";

		D2.L1="████████████";
		D2.L2="█          █";
		D2.L3="█ ██       █";
		D2.L4="█          █";
		D2.L5="█       ██ █";
		D2.L6="█          █";
		D2.L7="████████████";

		D3.L1="████████████";
		D3.L2="█          █";
		D3.L3="█ ██       █";
		D3.L4="█    ██    █";
		D3.L5="█       ██ █";
		D3.L6="█          █";
		D3.L7="████████████";

		D4.L1="████████████";
		D4.L2="█          █";
		D4.L3="█ ██    ██ █";
		D4.L4="█          █";
		D4.L5="█ ██    ██ █";
		D4.L6="█          █";
		D4.L7="████████████";

		D5.L1="████████████";
		D5.L2="█          █";
		D5.L3="█ ██    ██ █";
		D5.L4="█    ██    █";
		D5.L5="█ ██    ██ █";
		D5.L6="█          █";
		D5.L7="████████████";

		D6.L1="████████████";
		D6.L2="█          █";
		D6.L3="█ ██ ██ ██ █";
		D6.L4="█          █";
		D6.L5="█ ██ ██ ██ █";
		D6.L6="█          █";
		D6.L7="████████████";

				asciiArt [] Tabdice=new asciiArt [6] {D1,D2,D3,D4,D5,D6};
				int longueur=input.Length;
		string Ligne1="";
		string Ligne2="";
		string Ligne3="";
		string Ligne4="";
		string Ligne5="";
		string Ligne6="";
		string Ligne7="";
		for (int i=0;i<longueur;i++){
				Ligne1=Ligne1+Tabdice[(int)input[i]-49].L1+"\t";
				Ligne2=Ligne2+Tabdice[(int)input[i]-49].L2+"\t";
				Ligne3=Ligne3+Tabdice[(int)input[i]-49].L3+"\t";
				Ligne4=Ligne4+Tabdice[(int)input[i]-49].L4+"\t";
				Ligne5=Ligne5+Tabdice[(int)input[i]-49].L5+"\t";
				Ligne6=Ligne6+Tabdice[(int)input[i]-49].L6+"\t";
				Ligne7=Ligne7+Tabdice[(int)input[i]-49].L7+"\t";
		}
		Console.WriteLine(Ligne1);
		Console.WriteLine(Ligne2);
		Console.WriteLine(Ligne3);
		Console.WriteLine(Ligne4);
		Console.WriteLine(Ligne5);
		Console.WriteLine(Ligne6);
		Console.WriteLine(Ligne7);
	}


	public static void lecture_challenge(string [,]chall,int NbPlayer){//lecture des challenges encore disponibles du joueur actuel
		for (int i=0;i<13;i++){
			if (chall[NbPlayer,i]=="false"){Console.WriteLine("{0} : {1}",i+1,chall[0,i]);}
		}
	}

	public static void debut_tour (string [,] chall,int NbPlayer,joueurs [] Tabjoueurs,int NbTour,rounds [] Tour){//affichage de l'historique des tours au début de chaque tour de chaques joueurs
		Console.WriteLine($"\t/\tPoints de  {Tabjoueurs[0].pseudo} : {Tabjoueurs[0].score}\n\t|\tPoints de  {Tabjoueurs[1].pseudo} : {Tabjoueurs[1].score}\n\t|\tHistorique des tours:");
		for (int i=0; i<NbTour;i++){
			Console.WriteLine($"\t|\tAu tour {i+1} {Tabjoueurs[0].pseudo} à joué {chall[0,Tour[i].challengeP1] } pour {Tour[i].scoreP1} points et {Tabjoueurs[1].pseudo} à joué {chall[0,Tour[i].challengeP2]} pour {Tour[i].scoreP2} points ");
		}
		Console.WriteLine($"\t\\\tChallenge disponible pour vous({Tabjoueurs[NbPlayer].pseudo}) :");
		lecture_challenge(chall,NbPlayer+1);
	}

	public static void tour(int NbTour,rounds [] Tour,string [,] chall,ref joueurs [] Tabjoueurs){//Tour complet appelant les fonctions précédantes et enregistrant les valeurs
		Console.WriteLine($"==============>TOUR {NbTour+1}<==============");
		for (int Jo =0;Jo<2;Jo++){
			Console.WriteLine("__________________________________________________________");
			Console.WriteLine("tour {0} de {1} :",NbTour+1,Tabjoueurs[Jo].pseudo);
			if(NbTour!=0 ){
				debut_tour(chall,Jo,Tabjoueurs,NbTour,Tour);
			}
			Console.WriteLine("\n\tVoici vos dés :");
			int [] dicetour=tourparjoueur();
			string sure="n";
			int challtour=-1;
			int pointstour=-1;
			while (sure!="o"){
				challtour=(select_challenge(chall,Tabjoueurs[Jo].id));
				pointstour=(verif_challenge(challtour+1,dicetour));
				Console.Write("ce challenge vous rapportera {0} points, êtes vous sûr ? (o/n)",pointstour);
				sure=Console.ReadLine();
				while (sure!="o" && sure!="n"){
					Console.Write("Veuillez repondre par o ou n\nce challenge vous rapportera {0} points, êtes vous sûr ? (o/n)",pointstour);
					sure=Console.ReadLine();
				}
				if (sure=="n"){
					Console.Write("\n\tRappel de vos dés :\n\t");
					for (int i=0;i<5;i++){
    			    	Console.Write ("[{0}]",dicetour[i]);
    			    }
    			    Console.WriteLine("\n");
				}
			}
			chall[Tabjoueurs[Jo].id,challtour]="true";
			if (challtour<6){
				Tabjoueurs[Jo].scoremineur=Tabjoueurs[Jo].scoremineur+pointstour;
			}

			if (Jo==0){
				Tour[NbTour].diceP1=dicetour;
				Tour[NbTour].scoreP1=pointstour;
				Tour[NbTour].challengeP1=challtour;
			}
			else if (Jo==1){
				Tour[NbTour].diceP2=dicetour;
				Tour[NbTour].scoreP2=pointstour;
				Tour[NbTour].challengeP2=challtour;
			}

			Tabjoueurs[Jo].score=Tabjoueurs[Jo].score+pointstour;
		}
	}

	public static int select_challenge(string [,]chall,int NbPlayer){//appel de l'affichage des challenge dispo puis selection d'un challenge disponible
		Console.WriteLine("selectionnez le challenge : ");
		lecture_challenge(chall,NbPlayer);
		Console.Write("Votre choix : ");
		bool estnombre=true;
		int choixchall=0;
		while (choixchall >13 ||  choixchall<1 || chall[NbPlayer,choixchall-1]=="true" || estnombre==false){
			estnombre=int.TryParse(Console.ReadLine() ,out choixchall);
			if (choixchall >13 ||  choixchall<1 || chall[NbPlayer,choixchall-1]=="true"){
				Console.WriteLine("Erreur ceci n'est pas un challenge disponible \nselectionnez le challenge : ");
			}
		}
		return choixchall-1;
	}

	public static int verif_challenge(int challenge,int[] dice){//pour chaques challenge calcul le nombre de points qu'il apportera au joueurs
		int scoreCount=0;
		if(challenge<7){		//nombre de 1 à 6 (Pour chaque dés, vérifie si c'est le chiffre choisi par le joueur, si oui alors ce chiffre est ajouté au score)
			for (int d=0;d<5;d++){
				if (dice[d]==challenge){
					scoreCount=scoreCount+challenge;
				}
			}
		}
		else if (challenge==7){		//Brelan (Pour chaques dés, vérifie si la valeur de ce dé apparait en tout 3 fois dans le tableau de dé, si c'est le cas alors le score est égal à 3 fois la valeur de ce dé et la boucle se termine)
			bool Brelan=false;
			int d=0;
			while (Brelan==false && d<5){
				int count=0;
				for (int d2=d;d2<5;d2++){
					if (dice[d]==dice[d2]){
						count++;
					}
					if(count==3){
						Brelan=true;
						scoreCount=3*dice[d];
					}
				}
				d++;
			}
		}
		else if (challenge==8){		//carré (Pour chaques dés, vérifie si la valeur de ce dé apparait en tout 4 fois dans le tableau de dé, si c'est le cas alors le score est égal à 4 fois la valeur de ce dé et la boucle se termine)
			bool Carre=false;
			int d=0;
			while (Carre==false && d<5){
				int count=0;
				for (int d2=d;d2<5;d2++){
					if (dice[d]==dice[d2]){
						count++;
					}
					if(count==4){
						Carre=true;
						scoreCount=4*dice[d];
					}
				}
				d++;
			}
		}
		else if (challenge==9){ 		//full (Vérifie premièrement la présence d'un brelan puis vérifie si un chiffre différent de celui du brelan apparait 2 fois (en suivant les mêmes techniques que vu précédemant), si c'est le cas alors le score ajouté est de 25)
			bool Brelan=false;
			int d=0;
			int NbBrelan=0;
			while (Brelan==false && d<5){
				int count=0;
				for (int d2=d;d2<5;d2++){
					if (dice[d]==dice[d2]){
						count++;
					}
					if(count==3){
						Brelan=true;
						NbBrelan=dice[d];
					}
				}
				d++;
			}
			if (Brelan==true){
				bool Full=false;
				d=0;
				while (Full==false && d<5){
					int count=0;
					for (int d2=d;d2<5;d2++){
						if(dice[d]!=NbBrelan){
							if (dice[d]==dice[d2]){
								count++;
							}
							if(count==2){
								Full=true;
								scoreCount=25;
							}
						}
					}
					d++;
				}
			}
		}
		else if (challenge==10){ 			//petite suite (Pour chaque dés, vérifie si le tableau contient les chiffres valant ce dé-1, ce dé-2 et ce dé-3 si c'est le cas alors le score ajouté est de 30)
			bool petiteS=false;
			int d=0;
			while (petiteS==false && d<5){
				for (int d2=0;d2<5;d2++){
					if (dice[d]==dice[d2]-1){
						for (int d3=0;d3<5;d3++){
							if (dice[d]==dice[d3]-2){
								for (int d4=0;d4<5;d4++){
									if (dice[d]==dice[d4]-3){
										petiteS=true;
										scoreCount=30;
									}
								}
							}
						}
					}
				}
				d++;
			}
		}
		else if (challenge==11){			//grande suite (Pour chaque dés, vérifie si le tableau contient les chiffres valant ce dé-1, ce dé-2, ce dé-3 et ce dé-4 si c'est le cas alors le score ajouté est de 40)
			bool grandeS=false;
			int d=0;
			while (grandeS==false && d<5){
				for (int d2=0;d2<5;d2++){
					if (dice[d]==dice[d2]-1){
						for (int d3=0;d3<5;d3++){
							if (dice[d]==dice[d3]-2){
								for (int d4=0;d4<5;d4++){
									if (dice[d]==dice[d4]-3){
										for (int d5=0;d5<5;d5++){
											if (dice[d]==dice[d5]-4){
												grandeS=true;
												scoreCount=40;
											}
										}
									}
								}
							}
						}
					}
				}
				d++;
			}
		}
		else if (challenge==12){			//yams (Vérifie si touts les dés ont la même valeur, si oui alors le score ajouté est de 50)
			if (dice[0]==dice[1] && dice[1]==dice[2] && dice[2]==dice[3] && dice[3]==dice[4]){
					scoreCount=50;
			}
		}
		else if (challenge==13){			//chance (Le score est égal à la valeur de touts les dés additionnés)
			for (int d=0;d<5;d++){
				scoreCount=scoreCount+dice[d];
			}
		}
		return scoreCount;
	}

	public static void affichage(string input){// utilise la structure asciiArt pour y enregistrer chaques lignes de chaques lettres et ensuite y lire le nom du gagnant en enregistrant la suite de lettres ligne par ligne puis en affichant les lignes les unes après les autres. (Prend en compte les valeurs toutes les lettres en minuscule ou en majuscule (pas de différence à l'affichage) mais aussi "é,è,ë et ê", si un charactère différent est entré il sera remplacé par une tabulation)
		asciiArt A=new asciiArt();
		asciiArt B=new asciiArt();
		asciiArt C=new asciiArt();
		asciiArt D=new asciiArt();
		asciiArt E=new asciiArt();
		asciiArt F=new asciiArt();
		asciiArt G=new asciiArt();
		asciiArt H=new asciiArt();
		asciiArt I=new asciiArt();
		asciiArt J=new asciiArt();
		asciiArt K=new asciiArt();
		asciiArt L=new asciiArt();
		asciiArt M=new asciiArt();
		asciiArt N=new asciiArt();
		asciiArt O=new asciiArt();
		asciiArt P=new asciiArt();
		asciiArt Q=new asciiArt();
		asciiArt R=new asciiArt();
		asciiArt S=new asciiArt();
		asciiArt T=new asciiArt();
		asciiArt U=new asciiArt();
		asciiArt V=new asciiArt();
		asciiArt W=new asciiArt();
		asciiArt X=new asciiArt();
		asciiArt Y=new asciiArt();
		asciiArt Z=new asciiArt();

		A.L1=" █████     ";
		A.L2="██   ██    ";
		A.L3="███████    ";
		A.L4="██   ██    ";
		A.L5="██   ██    ";
		A.L6="           ";

		B.L1="██████     ";
		B.L2="██   ██    ";
		B.L3="██████     ";
		B.L4="██   ██    ";
		B.L5="██████     ";
		B.L6="           ";

		C.L1=" ██████    ";
		C.L2="██         ";
		C.L3="██         ";
		C.L4="██         ";
		C.L5=" ██████    ";
		C.L6="           ";

		D.L1="██████     ";
		D.L2="██   ██    ";
		D.L3="██   ██    ";
		D.L4="██   ██    ";
		D.L5="██████     ";
		D.L6="           ";

		E.L1="███████    ";
		E.L2="██         ";
		E.L3="█████      ";
		E.L4="██         ";
		E.L5="███████    ";
		E.L6="           ";

		F.L1="███████    ";
		F.L2="██         ";
		F.L3="█████      ";
		F.L4="██         ";
		F.L5="██         ";
		F.L6="           ";

		G.L1=" ██████    ";
		G.L2="██         ";
		G.L3="██   ███   ";
		G.L4="██    ██   ";
		G.L5=" ██████    ";
		G.L6="           ";

		H.L1="██   ██    ";
		H.L2="██   ██    ";
		H.L3="███████    ";
		H.L4="██   ██    ";
		H.L5="██   ██    ";
		H.L6="           ";

		I.L1="██         ";
		I.L2="██         ";
		I.L3="██         ";
		I.L4="██         ";
		I.L5="██         ";
		I.L6="           ";

		J.L1="     ██    ";
		J.L2="     ██    ";
		J.L3="     ██    ";
		J.L4="██   ██    ";
		J.L5=" █████     ";
		J.L6="           ";

		K.L1="██   ██    ";
		K.L2="██  ██     ";
		K.L3="█████      ";
		K.L4="██  ██     ";
		K.L5="██   ██    ";
		K.L6="           ";

		L.L1="██         ";
		L.L2="██         ";
		L.L3="██         ";
		L.L4="██         ";
		L.L5="███████    ";
		L.L6="           ";

		M.L1="███    ███ ";
		M.L2="████  ████ ";
		M.L3="██ ████ ██ ";
		M.L4="██  ██  ██ ";
		M.L5="██      ██ ";
		M.L6="           ";

		N.L1="███    ██  ";
		N.L2="████   ██  ";
		N.L3="██ ██  ██  ";
		N.L4="██  ██ ██  ";
		N.L5="██   ████  ";
		N.L6="           ";

		O.L1=" ██████    ";
		O.L2="██    ██   ";
		O.L3="██    ██   ";
		O.L4="██    ██   ";
		O.L5=" ██████    ";
		O.L6="           ";

		P.L1="██████     ";
		P.L2="██   ██    ";
		P.L3="██████     ";
		P.L4="██         ";
		P.L5="██         ";
		P.L6="           ";

		Q.L1=" ██████    ";
		Q.L2="██    ██   ";
		Q.L3="██    ██   ";
		Q.L4="██ ▄▄ ██   ";
		Q.L5=" ██████    ";
		Q.L6="    ▀▀     ";

		R.L1="██████     ";
		R.L2="██   ██    ";
		R.L3="██████     ";
		R.L4="██   ██    ";
		R.L5="██   ██    ";
		R.L6="           ";

		S.L1="███████    ";
		S.L2="██         ";
		S.L3="███████    ";
		S.L4="     ██    ";
		S.L5="███████    ";
		S.L6="           ";

		T.L1="████████   ";
		T.L2="   ██      ";
		T.L3="   ██      ";
		T.L4="   ██      ";
		T.L5="   ██      ";
		T.L6="           ";

		U.L1="██    ██   ";
		U.L2="██    ██   ";
		U.L3="██    ██   ";
		U.L4="██    ██   ";
		U.L5=" ██████    ";
		U.L6="           ";

		V.L1="██    ██   ";
		V.L2="██    ██   ";
		V.L3="██    ██   ";
		V.L4=" ██  ██    ";
		V.L5="  ████     ";
		V.L6="           ";

		W.L1="██     ██  ";
		W.L2="██     ██  ";
		W.L3="██  █  ██  ";
		W.L4="██ ███ ██  ";
		W.L5=" ███ ███   ";
		W.L6="           ";

		X.L1="██   ██    ";
		X.L2=" ██ ██     ";
		X.L3="  ███      ";
		X.L4=" ██ ██     ";
		X.L5="██   ██    ";
		X.L6="           ";

		Y.L1="██    ██   ";
		Y.L2=" ██  ██    ";
		Y.L3="  ████     ";
		Y.L4="   ██      ";
		Y.L5="   ██      ";
		Y.L6="           ";

		Z.L1="███████    ";
		Z.L2="   ███     ";
		Z.L3="  ███      ";
		Z.L4=" ███       ";
		Z.L5="███████    ";
		Z.L6="           ";

		asciiArt [] Tabascii=new asciiArt [26] {A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z};
		int longueur=input.Length;
		string Ligne1="";
		string Ligne2="";
		string Ligne3="";
		string Ligne4="";
		string Ligne5="";
		string Ligne6="";
		for (int i=0;i<longueur;i++){
			if (input[i]>=97 && input[i]<=122){
				Ligne1=Ligne1+Tabascii[(int)input[i]-97].L1+"\t";
				Ligne2=Ligne2+Tabascii[(int)input[i]-97].L2+"\t";
				Ligne3=Ligne3+Tabascii[(int)input[i]-97].L3+"\t";
				Ligne4=Ligne4+Tabascii[(int)input[i]-97].L4+"\t";
				Ligne5=Ligne5+Tabascii[(int)input[i]-97].L5+"\t";
				Ligne6=Ligne6+Tabascii[(int)input[i]-97].L6+"\t";
			}
			else if (input[i]>=65 && input[i]<=90){
				Ligne1=Ligne1+Tabascii[(int)input[i]-65].L1+"\t";
				Ligne2=Ligne2+Tabascii[(int)input[i]-65].L2+"\t";
				Ligne3=Ligne3+Tabascii[(int)input[i]-65].L3+"\t";
				Ligne4=Ligne4+Tabascii[(int)input[i]-65].L4+"\t";
				Ligne5=Ligne5+Tabascii[(int)input[i]-65].L5+"\t";
				Ligne6=Ligne6+Tabascii[(int)input[i]-65].L6+"\t";
			}
			else if ((input[i]>=200 && input[i]<=203 )||(input[i]>=232 && input[i]<=235 )){
				Ligne1=Ligne1+Tabascii[4].L1+"\t";
				Ligne2=Ligne2+Tabascii[4].L2+"\t";
				Ligne3=Ligne3+Tabascii[4].L3+"\t";
				Ligne4=Ligne4+Tabascii[4].L4+"\t";
				Ligne5=Ligne5+Tabascii[4].L5+"\t";
				Ligne6=Ligne6+Tabascii[4].L6+"\t";
			}
			else{
				Ligne1=Ligne1+"\t";
				Ligne2=Ligne2+"\t";
				Ligne3=Ligne3+"\t";
				Ligne4=Ligne4+"\t";
				Ligne5=Ligne5+"\t";
				Ligne6=Ligne6+"\t";
			}
		}
		Console.WriteLine(Ligne1);
		Console.WriteLine(Ligne2);
		Console.WriteLine(Ligne3);
		Console.WriteLine(Ligne4);
		Console.WriteLine(Ligne5);
		Console.WriteLine(Ligne6);
	}

	static void Main(){


		Console.WriteLine(" _  _    __    __  __ / ___ ");
		Console.WriteLine("( \\/ )  /__\\  (  \\/  ) / __)");
		Console.WriteLine(" \\  /  /(__)\\  )    (  \\__ \\");
		Console.WriteLine(" (__) (__)(__)(_/\\/\\_) (___/");				//affichage titre du jeu (en plusieurs lignes car je voulais mettre un délais entre chaque ligne mais je ne suis pas sur que ces commandes soient autorisées )
        string date =DateTime.Now.ToString("yyyy-MM-dd"); //enregistre la date actuelle dans la variable date
        Console.WriteLine(date);																		//affiche la date actuelle
		Console.WriteLine("");																				//saut de ligne

		string [,] chall = new string [3,13] {{"nombre de 1","nombre de 2","nombre de 3","nombre de 4","nombre de 5","nombre de 6","Brelan","Carre","Full","Petite suite","Grande suite","Yam's","Chance"},{"false","false","false","false","false","false","false","false","false","false","false","false","false"},{"false","false","false","false","false","false","false","false","false","false","false","false","false"}};//création du tableau des challenge contenant le nom du challenge ainsi que des faux booléens pour savoir si un joueur à déjà joué ce challenge


		string [] challjson = new string [13] {"nombre1","nombre2","nombre3","nombre4","nombre5","nombre6","brelan","carre","full","petite","grande","yams","chance"};//création du tableau contenant la version de nom des challenge à entrer dans le json

		joueurs P1=new joueurs();//création du joueur P1
		P1.score=0;
		P1.scoremineur=0;
		P1.id=1;
		Console.Write("Pseudo du joueur 1:");
		P1.pseudo=Console.ReadLine();

		Console.WriteLine("");

		joueurs P2=new joueurs();//création du joueur P2
		P2.score=0;
		P2.scoremineur=0;
		P2.id=2;
		Console.Write("Pseudo du joueur 2:");
		P2.pseudo=Console.ReadLine();

		rounds R1=new rounds();//création des structures de chaques tours
		rounds R2=new rounds();
		rounds R3=new rounds();
		rounds R4=new rounds();
		rounds R5=new rounds();
		rounds R6=new rounds();
		rounds R7=new rounds();
		rounds R8=new rounds();
		rounds R9=new rounds();
		rounds R10=new rounds();
		rounds R11=new rounds();
		rounds R12=new rounds();
		rounds R13=new rounds();
		rounds [] Tour = new rounds [13] {R1,R2,R3,R4,R5,R6,R7,R8,R9,R10,R11,R12,R13};//création d'un tableau contenant touts les tours

		joueurs [] Tabjoueurs = new joueurs [2] {P1,P2};//création d'un tableau contenant les joueurs

		for (int p=0;p<13;p++){										//répéter 13 fois l'appelle de la fonctions tour qui permet un tour de jeu complet
			tour(p,Tour,chall,ref Tabjoueurs);
		}

		P1=Tabjoueurs[0];//copier les données des joueurs du tableau dans les données des joueurs de base
		P2=Tabjoueurs[1];

		if (P1.scoremineur>=63){//vérifie si le joueur 1 à accès au bonus de score mineur
			P1.bonus=35;
		}
		if (P2.scoremineur>=63){//vérifie si le joueur 2 à accès au bonus de score mineur
			P2.bonus=35;
		}
/*		for (int p=0;p<13;p++){																	//AFFICHAGE DE LA PARTIE COMPLÈTE (en commentaire car non-demandé)
			Console.WriteLine("Tour {0}",p+1);
			Console.Write (P1.pseudo);
			for (int i=0;i<5;i++){
				Console.Write ("[{0}]",Tour[p].diceP1[i]);
        	}
        	Console.WriteLine("{0} => {1}",chall[0,Tour[p].challengeP1],Tour[p].scoreP1);
        	Console.Write (P2.pseudo);
			for (int i=0;i<5;i++){
				Console.Write ("[{0}]",Tour[p].diceP2[i]);
        	}
        	Console.WriteLine("{0} => {1}",chall[0,Tour[p].challengeP2],Tour[p].scoreP2);
        }*/

        P1.score=P1.score+P1.bonus;//aujout du bonus de P1 à son score total (si le bonus n'est pas atteint alors ajout de 0point)
        P2.score=P2.score+P2.bonus;//aujout du bonus de P1 à son score total (si le bonus n'est pas atteint alors ajout de 0point)


		Console.WriteLine("\n__________________________________________________________\n");
        Console.WriteLine("Score Final: \n{0} (joueur {1}) : {2} (bonus : {6})\n{3} (joueur {4}) : {5} (bonus : {7})",P1.pseudo,P1.id,P1.score,P2.pseudo,P2.id,P2.score,P1.bonus,P2.bonus);//affichage du score final

		Console.WriteLine("et le gagnant est :"); //affichage du gagnant en grand
		if(P1.score>P2.score){
			affichage(P1.pseudo);
		}
		else if(P2.score>P1.score){
			affichage(P2.pseudo);
		}
		else {
			Console.WriteLine("Personne... ==Égalité==");
		}

        /*ET MAINTENANT LA CREATION DU JSON*/
		StreamWriter file = new StreamWriter("partieyams.json");
		file.WriteLine("{{\n	\"parameters\": {{\n      \"code\": \"groupe5-217\",\n      \"date\": \"{0}\"\n    }},\n    \"players\": [\n      {{\n        \"id\": 1,\n        \"pseudo\": \"{1}\"\n      }},\n      {{\n        \"id\": 2,\n        \"pseudo\": \"{2}\"\n      }}\n    ],",date,P1.pseudo,P2.pseudo);//écriture du début du json contenant la date et les pseudos des joueurs

		file.WriteLine("	\"rounds\": [");
		string vir;
		for (int i=0;i<13;i++){//écriture de touts les tours
		if (i!=12){ vir=",";}
		else { vir="";}//si le tour est le dernier tour alors il ne doit pas y avoir de virgule à la fin
			file.WriteLine("      {{        \"id\": {0},\n        \"results\": [\n          {{\n            \"id_player\": 1,\n            \"dice\": [{1},{2},{3},{4},{5}],\n            \"challenge\": \"{6}\",\n            \"score\": {7}\n          }},\n          {{\n            \"id_player\": 2,\n            \"dice\": [{8},{9},{10},{11},{12}],\n            \"challenge\": \"{13}\",\n            \"score\": {14}\n          }}\n        ]\n      }}{15}",i+1,Tour[i].diceP1[0],Tour[i].diceP1[1],Tour[i].diceP1[2], Tour[i].diceP1[3],Tour[i].diceP1[4],challjson[Tour[i].challengeP1], Tour[i].scoreP1,Tour[i].diceP2[0],Tour[i].diceP2[1],Tour[i].diceP2[2], Tour[i].diceP2[3],Tour[i].diceP2[4],challjson[Tour[i].challengeP2], Tour[i].scoreP2,vir);
		}
		file.WriteLine("],\n    \"final_result\": [\n      {{\n        \"id_player\": 1,\n        \"bonus\": {0},\n        \"score\": {1}\n      }},\n      {{\n        \"id_player\": 2,\n        \"bonus\": {2},\n        \"score\": {3}\n      }}\n    ]\n}}",P1.bonus,P1.score,P2.bonus,P2.score);//écriture de la fin du json avec les score et les bonus
		file.Close();
	}
}
