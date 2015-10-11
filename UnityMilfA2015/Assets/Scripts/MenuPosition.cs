using UnityEngine;
using System;
using System.Collections;


public class MenuPosition : MonoBehaviour {

    //Un premier tableau comprenant les joueurs dans cette ordre (Rouge, Bleu, vert, jaune) que l'on doit drager dans l'interface de unity  
    public GameObject[] Icones;

    public GameObject[] joueurs;
    
    //Un tableau qui va contenir les ammos de tous les joueurs
    public int[] ammo;
    
    //Tableau qui va contenir la postion des joueurs quand le trie sera effectue. On doit lui donner les diffrentes image des personnage dans l'interface
    public GameObject[] joueursPosition;
    
    //Variable pour garder en memoire la position dans le canvas que l'on veut que chacun aille selon leur ammo
    public float posPour1erPositionX = -9;
    public float posPour2ePositionX = -9;
    public float posPour3ePositionX = -9;
    public float posPour4ePositionX = -9;

    public float posPour1erPositionY = 3;
    public float posPour2ePositionY = 2;
    public float posPour3ePositionY = 1;
    public float posPour4ePositionY = 0;

    public int nbrJoueur = 0;

    public bool finiTrier = false;

	//Ce update sert a trier les positions des joueurs selon le nombre de Ammo
	void Update () 
    {
        if(nbrJoueur != 0)
        {
            //On creer le tableau qui contient juste les munitions
            for (int i = 0; i < joueurs.Length; i++)
            {
                ammo[i] = joueurs[i].GetComponent<PlayerShoot>().munition;
            }

            Icones.CopyTo(joueursPosition, 0);

            //On doit choisir la bonne fonction selon le nombre de joueur
            switch (nbrJoueur)
            {
                case 2:
                    trierPour2Joueur();
                    break;

                case 3: 
                    trierPour4Joueur();
                    break;

                case 4: 
                    trierPour4Joueur();
                    break;
            }  
        }
	}

    //Trier le score si 2 joueur dans la partie
    public void trierPour2Joueur()
    {
        //On trie se tableau
        if (ammo[0] >= ammo[1])
        {
            joueursPosition[0] = Icones[0];
            joueursPosition[1] = Icones[1];
        }
        else
        {
            joueursPosition[0] = Icones[1];
            joueursPosition[1] = Icones[0];   
        }

       //Apres on doit affecter les positions dans le canvas

        joueursPosition[0].gameObject.transform.localPosition = new Vector3(posPour1erPositionX, posPour1erPositionY, 10);
        joueursPosition[1].gameObject.transform.localPosition = new Vector3(posPour2ePositionX, posPour2ePositionY, 10);
    }

    public void trierPour3Joueur()
    {
        Icones.CopyTo(joueursPosition, 0);
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
        joueursPosition[2].gameObject.transform.localPosition = new Vector3(posPour1erPositionX, posPour1erPositionY, 10);
        joueursPosition[1].gameObject.transform.localPosition = new Vector3(posPour2ePositionX, posPour2ePositionY, 10);
        joueursPosition[0].gameObject.transform.localPosition = new Vector3(posPour3ePositionX, posPour3ePositionY, 10);
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
        joueursPosition[3].gameObject.transform.localPosition = new Vector3(posPour1erPositionX, posPour1erPositionY, 10);
        joueursPosition[2].gameObject.transform.localPosition = new Vector3(posPour2ePositionX, posPour2ePositionY, 10);
        joueursPosition[1].gameObject.transform.localPosition = new Vector3(posPour3ePositionX, posPour3ePositionY, 10);
        joueursPosition[0].gameObject.transform.localPosition = new Vector3(posPour4ePositionX, posPour4ePositionY, 10);



    }

    public void setNbrJoueurs(int nbr)
    {
        nbrJoueur = nbr;
    }
}
