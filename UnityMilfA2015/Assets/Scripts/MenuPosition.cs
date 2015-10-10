using UnityEngine;
using System;
using System.Collections;

public class MenuPosition : MonoBehaviour {
	
    public GameObject[] joueurs;
    public int[] ammo;
    public GameObject[] lesPositionDansCanvas;
    public GameObject[] joueursPosition;
    
    //Variable pour garder en memoire la position dans le canvas que l'on veut que chacun aille selon leur ammo
    public float posPour1erPosition;
    public float posPour2ePosition;
    public float posPour3ePosition;
    public float posPour4ePosition;

    public int nbrJoueur = 0;
    public MainMenu leMainMenu;

    public bool finiTrier = false;

	//Ce update sert a trier les positions des joueurs selon le nombre de Ammo
	void Update () {

        //On commence par aller voir combien de joueur
        nbrJoueur = leMainMenu.GetNbrJoueur();

        //On creer le tableau qui contient juste les munitions
        for (int i = 0; i < joueurs.Length; i++)
        {
            ammo[i] = joueurs[i].GetComponent<PlayerShoot>().munition;
        }

        //Mettre le tableau de joueurs dans le tableau des position pour avoir les meme indexe que dans le tableau de ammo
        joueursPosition = joueurs;


        //On doit choisir la bonne fonction selon le nombre de joueur
        switch (nbrJoueur)
        {
            case 2:
                trierPour2Joueur();
                break;

            case 3: trierPour3Joueur();
                break;

            case 4: trierPour4Joueur();
                break;
        }  
	}

    //Trier le score si 2 joueur dans la partie
    public void trierPour2Joueur()
    {
        //On trie se tableau
        if (ammo[0] > ammo[1])
        {
            joueursPosition[0] = joueurs[0];
            joueursPosition[1] = joueurs[1];
        }
        else
        {
            joueursPosition[0] = joueurs[1];
            joueursPosition[1] = joueurs[0];
        }

       //Apres on doit affecter les positions dans le canvas

        joueursPosition[1].gameObject.transform.position = new Vector2(0, posPour1erPosition);
        joueursPosition[0].gameObject.transform.position = new Vector2(0, posPour2ePosition);
    }

    public void trierPour3Joueur()
    {
        //On fait un bubble sort sur le tableau de int ammo et on recopie les meme mouvements dans le tableau des joueurPosition
        for (int i = ammo.Length - 1; i > 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                if (ammo[j] > ammo[j + 1])
                {
                    int highValue = ammo[j];
                    GameObject highJoueur = joueursPosition[j];

                    ammo[j] = ammo[j + 1];
                    joueursPosition[j] = joueursPosition[j + 1];

                    ammo[j + 1] = highValue;
                    joueursPosition[j + 1] = highJoueur;
                }
            }
        }

        //Apres on doit affecter les positions dans le canvas
        joueursPosition[2].gameObject.transform.position = new Vector2(0, posPour1erPosition);
        joueursPosition[1].gameObject.transform.position = new Vector2(0, posPour2ePosition);
        joueursPosition[0].gameObject.transform.position = new Vector2(0, posPour3ePosition);

    }

    public void trierPour4Joueur()
    {
        for (int i = ammo.Length - 1; i > 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                if (ammo[j] > ammo[j + 1])
                {
                    int highValue = ammo[j];
                    GameObject highJoueur = joueursPosition[j];

                    ammo[j] = ammo[j + 1];
                    joueursPosition[j] = joueursPosition[j + 1];

                    ammo[j + 1] = highValue;
                    joueursPosition[j + 1] = highJoueur;
                }
            }
        }

        //Apres on doit affecter les positions dans le canvas
        joueursPosition[3].gameObject.transform.position = new Vector2(0, posPour1erPosition);
        joueursPosition[2].gameObject.transform.position = new Vector2(0, posPour2ePosition);
        joueursPosition[1].gameObject.transform.position = new Vector2(0, posPour3ePosition);
        joueursPosition[0].gameObject.transform.position = new Vector2(0, posPour4ePosition);
    }
}
