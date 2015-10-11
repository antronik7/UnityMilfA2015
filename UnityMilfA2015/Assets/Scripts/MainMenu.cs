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
    public float maxMonterCam = 14f;

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

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public GameObject ScoreP1;
    public GameObject ScoreP2;
    public GameObject ScoreP3;
    public GameObject ScoreP4;

    public GameObject J1Control;
    public GameObject J1Control2;
    public GameObject J2Control;
    public GameObject J3Control;
    public GameObject J4Control;

    public GameObject RoundsText;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;
    public int scorePlayer3 = 0;
    public int scorePlayer4 = 0;

    private AudioSource Source;
    public AudioClip VoixDebut;
    public AudioClip VoixDebut2;
    public AudioClip VoixDebut3;
    public AudioClip Musique;
    public AudioClip VoixFin;

    public GameObject forme1;
    public GameObject forme2;
    public GameObject forme3;
    public GameObject formeFinal;
    public GameObject fleche1;
    public GameObject fleche2;
    public GameObject fleche3;
    public GameObject fleche4;
    public GameObject win;

    public GameObject control;
    public GameObject lettreX;
    public GameObject lettreA;

    public GameObject rayon;

    public bool dejaJouer = false;

    private bool pasDeGagnant = true;


    void Awake()
    {
        CommencerJeu = false;
        Source = GetComponent<AudioSource>();
    }

    //Fonction update du menu. En se moment on s'en sert juste pour faire le mouvement de la cam
    void Update()
    {
        if(faireMouvementCam)
        {
            Camera.main.transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
        }

        if (Camera.main.transform.position.y > CameraY + 14)
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
        J3Control.SetActive(false);
        J4Control.SetActive(false);
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);
        DetruireBtnNbrJoueur();
	}

    //Fonction appeler quand on click sur le bouton btn2Joueur
    public void troisJoueurs()
    {

        PlayerPrefs.SetInt("nrbJoueur", 3);
        nbrJoueur = 3;
        J4Control.SetActive(false);
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);
        DetruireBtnNbrJoueur();
    }

    //Fonction appeler quand on click sur le bouton btn2Joueur
    public void quatreJoueurs()
    {

        PlayerPrefs.SetInt("nrbJoueur", 4);
        nbrJoueur = 4;
        GetComponent<MenuPosition>().setNbrJoueurs(nbrJoueur);

        DetruireBtnNbrJoueur();
    }

    //Fonction appler quand on click sur le bouton btnClavier
    public void Clavier()
    {
        PlayerPrefs.SetInt("clavier", 1);
        clavier = true;
        J1Control.SetActive(false);
        MonterCam();
        DetruireBtnControle();
    }

    //Fonction appler quand on click sur le bouton btnClavier
    public void Manette()
    {
        PlayerPrefs.SetInt("clavier", 0);
        clavier = false;
        J1Control2.SetActive(false);
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

        if (!dejaJouer)
        {
            forme1.SetActive(false);
            forme2.SetActive(false);
            forme3.SetActive(false);
            formeFinal.SetActive(false);
            fleche1.SetActive(false);
            fleche2.SetActive(false);
            fleche3.SetActive(false);
            fleche4.SetActive(false);
            win.SetActive(false);

            control.SetActive(true);
            lettreX.SetActive(true);
            lettreA.SetActive(true);
        }

        AfficherBtnControle();
    }

    //Fonction qui detruit les btn pour le choix du nombre de joueur
    public void DetruireBtnControle()
    {
        btnClavier.SetActive(false);
        btnManette.SetActive(false);

        if (!dejaJouer)
        {
            control.SetActive(false);
            lettreX.SetActive(false);
            lettreA.SetActive(false);
        }

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
        

        StartCoroutine(MaCoroutine());
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

            player1.GetComponent<PlayerController>().initialiserMesControle(1);
            player1.GetComponent<PlayerShoot>().initialiserMesControle(1);
            player1.GetComponent<PlayerShoot>().initialiserAngle(0);

            switch (nbrJoueur - 1)
            {
                case 1:
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("2Jump", "1JumpManette");

                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);
                    break;
                
                case 2:
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("2Jump", "1JumpManette");

                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);

                    PlayerPrefs.SetString("3Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("3Fire", "2FireManette");
                    PlayerPrefs.SetString("3Jump", "2JumpManette");

                    player3.GetComponent<PlayerController>().initialiserMesControle(3);
                    player3.GetComponent<PlayerShoot>().initialiserMesControle(3);
                    break;
                
                case 3: 
                    PlayerPrefs.SetString("2Horizontal", "1HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "1VerticalManette");
                    PlayerPrefs.SetString("2Fire", "1FireManette");
                    PlayerPrefs.SetString("2Jump", "1JumpManette");

                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);

                    PlayerPrefs.SetString("3Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("3Fire", "2FireManette");
                    PlayerPrefs.SetString("3Jump", "2JumpManette");

                    player3.GetComponent<PlayerController>().initialiserMesControle(3);
                    player3.GetComponent<PlayerShoot>().initialiserMesControle(3);

                    PlayerPrefs.SetString("4Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("4Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("4Fire", "3FireManette");
                    PlayerPrefs.SetString("4Jump", "3JumpManette");

                    player4.GetComponent<PlayerController>().initialiserMesControle(4);
                    player4.GetComponent<PlayerShoot>().initialiserMesControle(4);
                    break;
            }
        }
        else
        {
            //Mettre controle 
            PlayerPrefs.SetString("1Horizontal", "1HorizontalManette");
            PlayerPrefs.SetString("1Vertical", "1VerticalManette");
            PlayerPrefs.SetString("1Fire", "1FireManette");
            PlayerPrefs.SetString("1Jump", "1JumpManette");

            player1.GetComponent<PlayerController>().initialiserMesControle(1);
            player1.GetComponent<PlayerShoot>().initialiserMesControle(1);
            player1.GetComponent<PlayerShoot>().initialiserAngle(1);


            switch (nbrJoueur - 1)
            {
                case 1:
                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");
 
                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);
                    break;

                case 2:

                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");

                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);

                    PlayerPrefs.SetString("3Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("3Fire", "3FireManette");
                    PlayerPrefs.SetString("3Jump", "3JumpManette");

                    player3.GetComponent<PlayerController>().initialiserMesControle(3);
                    player3.GetComponent<PlayerShoot>().initialiserMesControle(3);

                    break;

                case 3:
                    PlayerPrefs.SetString("2Horizontal", "2HorizontalManette");
                    PlayerPrefs.SetString("2Vertical", "2VerticalManette");
                    PlayerPrefs.SetString("2Fire", "2FireManette");
                    PlayerPrefs.SetString("2Jump", "2JumpManette");

                    player2.GetComponent<PlayerController>().initialiserMesControle(2);
                    player2.GetComponent<PlayerShoot>().initialiserMesControle(2);

                    PlayerPrefs.SetString("3Horizontal", "3HorizontalManette");
                    PlayerPrefs.SetString("3Vertical", "3VerticalManette");
                    PlayerPrefs.SetString("3Fire", "3FireManette");
                    PlayerPrefs.SetString("3Jump", "3JumpManette");

                    player3.GetComponent<PlayerController>().initialiserMesControle(3);
                    player3.GetComponent<PlayerShoot>().initialiserMesControle(3);

                    PlayerPrefs.SetString("4Horizontal", "4HorizontalManette");
                    PlayerPrefs.SetString("4Vertical", "4VerticalManette");
                    PlayerPrefs.SetString("4Fire", "4FireManette");
                    PlayerPrefs.SetString("4Jump", "4JumpManette");

                    player4.GetComponent<PlayerController>().initialiserMesControle(4);
                    player4.GetComponent<PlayerShoot>().initialiserMesControle(4);

                    break;
            }
        }

        faireMouvementCam = true;
        ImageTitle.SetActive(false);

        if (dejaJouer)
        {
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            ScoreP1.SetActive(false);
            ScoreP2.SetActive(false);
            ScoreP3.SetActive(false);
            ScoreP4.SetActive(false);
            RoundsText.SetActive(false);
        }

        loadGame();
    }

    public void initialiserMenu()
    {
        ImageTitle.SetActive(true);

        dejaJouer = alreadyPlayed();

        if (!dejaJouer)
        {
            forme1.SetActive(true);
            forme2.SetActive(true);
            forme3.SetActive(true);
            formeFinal.SetActive(true);
            fleche1.SetActive(true);
            fleche2.SetActive(true);
            fleche3.SetActive(true);
            fleche4.SetActive(true);
            win.SetActive(true);
        }
        else
        {
            P1.SetActive(true);
            P2.SetActive(true);
            P3.SetActive(true);
            P4.SetActive(true);

            UnityEngine.UI.Text text = ScoreP1.GetComponent<UnityEngine.UI.Text>();
            text.text = "x" + scorePlayer1.ToString();

            text = ScoreP2.GetComponent<UnityEngine.UI.Text>();
            text.text = "x" + scorePlayer2.ToString();

            text = ScoreP3.GetComponent<UnityEngine.UI.Text>();
            text.text = "x" + scorePlayer3.ToString();

            text = ScoreP4.GetComponent<UnityEngine.UI.Text>();
            text.text = "x" + scorePlayer4.ToString();

            ScoreP1.SetActive(true);
            ScoreP2.SetActive(true);
            ScoreP3.SetActive(true);
            ScoreP4.SetActive(true);

            RoundsText.SetActive(true);
        }

        btnDeuxPlayer.SetActive(true);
        btnTroisPlayer.SetActive(true);
        btnQuatrePlayer.SetActive(true);
        initialiserControle();
    }

    IEnumerator MaCoroutine()
    {
        player1.GetComponent<PlayerController>().disableMovement = true;
        player1.GetComponent<PlayerShoot>().disableMovement = true;

        player2.GetComponent<PlayerController>().disableMovement = true;
        player2.GetComponent<PlayerShoot>().disableMovement = true;

        player3.GetComponent<PlayerController>().disableMovement = true;
        player3.GetComponent<PlayerShoot>().disableMovement = true;

        player4.GetComponent<PlayerController>().disableMovement = true;
        player4.GetComponent<PlayerShoot>().disableMovement = true;

        Source.clip = VoixDebut;
        Source.Play();

        yield return new WaitForSeconds(8f);

        Source.clip = VoixDebut2;
        Source.Play();

        yield return new WaitForSeconds(2f);

        Source.clip = VoixDebut3;
        Source.Play();

        yield return new WaitForSeconds(3f);

        Source.clip = Musique;
        Source.Play();
        Source.volume = 0.1f;
        Source.loop = true;

        J1Control2.SetActive(false);
        J1Control.SetActive(false);
        J2Control.SetActive(false);
        J3Control.SetActive(false);
        J4Control.SetActive(false);


        player1.GetComponent<PlayerController>().disableMovement = false;
        player1.GetComponent<PlayerShoot>().disableMovement = false;

        player2.GetComponent<PlayerController>().disableMovement = false;
        player2.GetComponent<PlayerShoot>().disableMovement = false;

        player3.GetComponent<PlayerController>().disableMovement = false;
        player3.GetComponent<PlayerShoot>().disableMovement = false;

        player4.GetComponent<PlayerController>().disableMovement = false;
        player4.GetComponent<PlayerShoot>().disableMovement = false;

        CommencerJeu = true;
    }

    public bool alreadyPlayed()
    {


        if (PlayerPrefs.HasKey("ScoreJoueur1"))
        {
            scorePlayer1 = PlayerPrefs.GetInt("ScoreJoueur1");
        }

        if (PlayerPrefs.HasKey("ScoreJoueur2"))
        {
            scorePlayer2 = PlayerPrefs.GetInt("ScoreJoueur2");
        }

        if (PlayerPrefs.HasKey("ScoreJoueur3"))
        {
            scorePlayer3 = PlayerPrefs.GetInt("ScoreJoueur3");
        }

        if (PlayerPrefs.HasKey("ScoreJoueur4"))
        {
            scorePlayer4 = PlayerPrefs.GetInt("ScoreJoueur4");
        }

        if (scorePlayer1 != 0 || scorePlayer2 != 0 || scorePlayer3 != 0 || scorePlayer4 != 0)
        {
            return true;
        }

        return false;
        
    }

    public void faireGagner(string nomJoueur)
    {
        if(pasDeGagnant)
        {
            GameObject Joueur;
            pasDeGagnant = false;
            CommencerJeu = false;

            player1.GetComponent<PlayerController>().disableMovement = true;
            player1.GetComponent<PlayerShoot>().disableMovement = true;
            player1.GetComponent<PlayerController>().disableHurt = true;

            player2.GetComponent<PlayerController>().disableMovement = true;
            player2.GetComponent<PlayerShoot>().disableMovement = true;
            player2.GetComponent<PlayerController>().disableHurt = true;

            player3.GetComponent<PlayerController>().disableMovement = true;    
            player3.GetComponent<PlayerShoot>().disableMovement = true;
            player3.GetComponent<PlayerController>().disableHurt = true;

            player4.GetComponent<PlayerController>().disableMovement = true;
            player4.GetComponent<PlayerShoot>().disableMovement = true;
            player4.GetComponent<PlayerController>().disableHurt = true;

            if (nomJoueur == player1.name)
                Joueur = player1;
           
            else if (nomJoueur == player2.name)
                Joueur = player2;
            
            else if (nomJoueur == player3.name)
                Joueur = player3;
            
            else
                Joueur = player4;

            StartCoroutine(Rayon(Joueur, nomJoueur));
        }
    }

    IEnumerator Rayon(GameObject Joueur, string Nom)
    {
        yield return new WaitForSeconds(2f);

        Source.clip = VoixFin;
        Source.volume = 1f;
        Source.Play();

        yield return new WaitForSeconds(1f);

        GameObject clone = Instantiate(rayon, new Vector3(Joueur.transform.position.x, Camera.main.transform.position.y + 8, 0), Quaternion.identity) as GameObject;
        clone.GetComponent<ScriptBeam>().nameGagnant = Nom;

        yield return new WaitForSeconds(6f);

        if (Nom == player1.name)
        {
            if (PlayerPrefs.HasKey("ScoreJoueur1"))
            {
                PlayerPrefs.SetInt("ScoreJoueur1", PlayerPrefs.GetInt("ScoreJoueur1") + 1);
            }
            else
                PlayerPrefs.SetInt("ScoreJoueur1", 1);
            Application.LoadLevel("P1WIN");
        }

        else if (Nom == player2.name)
        {
            if (PlayerPrefs.HasKey("ScoreJoueur2"))
            {
                PlayerPrefs.SetInt("ScoreJoueur2", PlayerPrefs.GetInt("ScoreJoueur2") + 1);
            }
            else
                PlayerPrefs.SetInt("ScoreJoueur2", 1);
            Application.LoadLevel("P2WIN");
        }

        else if (Nom == player3.name)
        {
            if (PlayerPrefs.HasKey("ScoreJoueur3"))
            {
                PlayerPrefs.SetInt("ScoreJoueur3", PlayerPrefs.GetInt("ScoreJoueur3") + 1);
            }
            else
                PlayerPrefs.SetInt("ScoreJoueur3", 1);
            Application.LoadLevel("P3WIN");
        }

        else
        {
            if (PlayerPrefs.HasKey("ScoreJoueur4"))
            {
                PlayerPrefs.SetInt("ScoreJoueur4", PlayerPrefs.GetInt("ScoreJoueur4") + 1);
            }
            else
                PlayerPrefs.SetInt("ScoreJoueur4", 1);
            Application.LoadLevel("P4WIN");
        }
    }
}
