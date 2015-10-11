using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    private float CameraY;
    public bool CommencerJeu;
   // public float CameraSpeed = 0.3f;
    public GameObject btnDeuxPlayer;
    public GameObject btnTroisPlayer;
    public GameObject btnQuatrePlayer;

    public GameObject btnClavier;
    public GameObject btnManette;

    public int nbrJoueur;
    public bool clavier;

    public float CameraSpeed = 3.3f;
    public bool faireMouvementCam = false;
    public float maxMonterCam = 5f;

    public bool faireMouvementBtnJoueur = false;
    public float MenuSpeed = 0.1f;

    public GameObject ImageTitle;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject iconePlayer1;
    public GameObject iconePlayer2;
    public GameObject iconePlayer3;
    public GameObject iconePlayer4;


    void Awake()
    {
        CommencerJeu = false;
    }

    //Fonction update du menu. En se moment on s'en sert juste pour faire le mouvement de la cam
    void Update()
    {
        if(faireMouvementCam)
        {
            Camera.main.transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
        }

        if (Camera.main.transform.position.y > CameraY + 7)
        {
            faireMouvementCam = false;
        }

        /*if (faireMouvementBtnJoueur)
        {
            btnDeuxPlayer.transform.Translate(Vector3.down *  MenuSpeed * Time.deltaTime);
        }*/

        /*if (btnDeuxPlayer.transform.position.y < CameraY + 7)
        {
            faireMouvementCam = false;
        }*/


    }

    //Fonction qui setActive False les bouton pour les controle
    void Start()
    {
        initialiserMenu();
    }

	//Fonction appeler quand on click sur le bouton btn2Joueur
	public void deuxJoueurs () 
    {
        PlayerPrefs.SetInt("nrbJoueur", 2);
        nbrJoueur = 2;
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);

        MonterCam();
        DetruireBtnNbrJoueur();
	}

    //Fonction appeler quand on click sur le bouton btn2Joueur
    public void troisJoueurs()
    {

        PlayerPrefs.SetInt("nrbJoueur", 3);
        nbrJoueur = 3;
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);
        
        MonterCam();
        DetruireBtnNbrJoueur();
    }

    //Fonction appeler quand on click sur le bouton btn2Joueur
    public void quatreJoueurs()
    {

        PlayerPrefs.SetInt("nrbJoueur", 4);
        nbrJoueur = 4;
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);

        MonterCam();
        DetruireBtnNbrJoueur();
    }

    //Fonction appler quand on click sur le bouton btnClavier
    public void Clavier()
    {

        PlayerPrefs.SetInt("clavier", 1);
        clavier = true;
        MonterCam();
        DetruireBtnControle();
    }

    //Fonction appler quand on click sur le bouton btnClavier
    public void Manette()
    {

        PlayerPrefs.SetInt("clavier", 0);
        clavier = false;
        MonterCam();
        DetruireBtnControle();
    }

    //Fonction qui fait monter la Main Camera POUR LE MOMENT ON SUPPRIME LES BOUTON DE L'ECRAN
    public void MonterCam()
    {
        CameraY = Camera.main.transform.position.y;
        faireMouvementCam = true;
    }

    //Fonction qui detruit les btn pour le choix du nombre de joueur
    public void DetruireBtnNbrJoueur()
    {

        //faireMouvementBtnJoueur = true;

        btnDeuxPlayer.SetActive(false);
        btnTroisPlayer.SetActive(false);
        btnQuatrePlayer.SetActive(false);
        AfficherBtnControle();
    }

    //Fonction qui detruit les btn pour le choix du nombre de joueur
    public void DetruireBtnControle()
    {
        btnClavier.SetActive(false);
        btnManette.SetActive(false);

        assignerControle();
    }

    //Fonction qui affiche les bouton controle
    public void AfficherBtnControle()
    {
        btnClavier.SetActive(true);
        btnManette.SetActive(true);
    }


    //Fonctoin qui load la prochaine Scene
    public void loadGame()
    {
        CommencerJeu = true;

        //Activer les joueurs
        player1.SetActive(true);
        player2.SetActive(true);

        iconePlayer1.SetActive(true);
        iconePlayer2.SetActive(true);

        switch (nbrJoueur)
        {
            case 3: player3.SetActive(true);
                    iconePlayer3.SetActive(true);
                break;
            case 4: player3.SetActive(true);
                    player4.SetActive(true);
                    iconePlayer3.SetActive(true);
                    iconePlayer4.SetActive(true);
                break;
        }

    }

    //Fonction qui reinitialise les controles des joueurs
    public void initialiserControle()
    {
        //Premier Player
        PlayerPrefs.SetString("1Horizontal", "");
        PlayerPrefs.SetString("1Vertical", "");
        PlayerPrefs.SetString("1Fire", "");
        PlayerPrefs.SetString("1Jump", "");

        //Deuxieme Player
        PlayerPrefs.SetString("2Horizontal", "");
        PlayerPrefs.SetString("2Vertical", "");
        PlayerPrefs.SetString("2Fire", "");
        PlayerPrefs.SetString("2Jump", "");

        //Troisieme Player
        PlayerPrefs.SetString("3Horizontal", "");
        PlayerPrefs.SetString("3Vertical", "");
        PlayerPrefs.SetString("3Fire", "");
        PlayerPrefs.SetString("3Jump", "");

        //Quatrieme
        PlayerPrefs.SetString("4Horizontal", "");
        PlayerPrefs.SetString("4Vertical", "");
        PlayerPrefs.SetString("4Fire", "");
        PlayerPrefs.SetString("4Jump", "");

        clavier = true;
        nbrJoueur = 2;
    }

    //Fonction pour assigner les bons controle
    public void assignerControle()
    {
        if (clavier)
        {
            //Mettre controle clvier au joueur 1
            PlayerPrefs.SetString("1Horizontal", "1HorizontalClavier");
            PlayerPrefs.SetString("1Vertical", "1VerticalClavier");
            PlayerPrefs.SetString("1Fire", "1FireClavier");
            PlayerPrefs.SetString("1Jump", "1JumpClavier");

            switch (nbrJoueur)
            {
                case 1:
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("1Jump", "1JumpManette");
                    break;
                
                case 2:
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("2Jump", "1JumpManette");

                    PlayerPrefs.SetString("3Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("3Fire", "2FireManette");
                    PlayerPrefs.SetString("3Jump", "2JumpManette");
                    break;
                
                case 3: 
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("2Jump", "1JumpManette");

                    PlayerPrefs.SetString("3Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("3Fire", "2FireManette");
                    PlayerPrefs.SetString("3Jump", "2JumpManette");

                    PlayerPrefs.SetString("4Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("4Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("4Fire", "3FireManette");
                    PlayerPrefs.SetString("4Jump", "3JumpManette");
                    break;
            }
        }
        else
        {
            //Mettre controle 
            PlayerPrefs.SetString("1Horizontal", "1HorizontalManette");
            PlayerPrefs.SetString("1Vertical", "1VerticalManette");
            PlayerPrefs.SetString("1Fire", "1Fire1");
            PlayerPrefs.SetString("1Jump", "1JumpManette");

            switch (nbrJoueur)
            {
                case 1:
                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");
                    break;

                case 2:

                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");

                    PlayerPrefs.SetString("3Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("3Fire", "3FireManette");
                    PlayerPrefs.SetString("3Jump", "3JumpManette");
                    break;

                case 3:
                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");

                    PlayerPrefs.SetString("3Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("3Fire", "3FireManette");
                    PlayerPrefs.SetString("3Jump", "3JumpManette");

                    PlayerPrefs.SetString("4Horizontal", "4HorizontalManette");
                    PlayerPrefs.SetString("4Vertical", "4VerticalManette");
                    PlayerPrefs.SetString("4Fire", "4FireManette");
                    PlayerPrefs.SetString("4Jump", "4JumpManette");

                    break;
            }
        }

        maxMonterCam = maxMonterCam*2;
        faireMouvementCam = true;
        ImageTitle.SetActive(false);
        loadGame();
    }

    public void initialiserMenu()
    {
        ImageTitle.SetActive(true);
        btnDeuxPlayer.SetActive(true);
        btnTroisPlayer.SetActive(true);
        btnQuatrePlayer.SetActive(true);
        initialiserControle();
    }
}
