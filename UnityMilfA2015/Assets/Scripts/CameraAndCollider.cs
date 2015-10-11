using UnityEngine;
using System.Collections;

public class CameraAndCollider : MonoBehaviour
{
    private int NombreEtage = 9;
    private GameObject Mur;
    private bool FinAscension;
    private Camera Cam;
    private GameObject Objet, Objet2, Objet3, ObjetP2;
    private MainMenu Menu;
    private GameObject Plateforme;
    private GameObject Pixel;
    private GameObject Spike;
    private GameObject SpikeInst;
    public GameObject ObjetP;
    public GameObject ScriptMenu;
    public float CameraSpeed;
    public GameObject Plateforme1;
    public GameObject Plateforme2;
    public GameObject Plateforme3;
    public GameObject Plateforme4;    

    public static float PixelsToUnits = 1f;
    public static float Scale = 1f;

    public Vector2 NativeResolution = new Vector2(240, 160);
    
    public int HauteurMax;

    void Awake()
    {
        Cam = GetComponentInParent<Camera>();
        FinAscension = false;
        Menu = ScriptMenu.GetComponent<MainMenu>();
        Mur = (GameObject)Resources.Load("Wall");
        Spike = (GameObject)Resources.Load("Spikes");

        if(Cam.orthographic)
            Scale = Screen.height / NativeResolution.y;
    }

    void Update()
    {
        if(Menu.CommencerJeu)
        {
            if (Cam.transform.position.y < HauteurMax)
                Cam.transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
            else
                FinAscension = true;

            if (Cam.transform.position.y < HauteurMax + 15 && FinAscension)
                Cam.transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
        }

        if (Cam.transform.position.y % 110 < 100.2 && Cam.transform.position.y % 110 > 100.12)
            Instantiate(Mur).transform.Translate(0, Cam.transform.position.y + 6, 0);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name != "Player1" && other.gameObject.name != "Player2" && other.gameObject.name != "Player3" && other.gameObject.name != "Player4")
            Destroy(other.gameObject);

        if (other.transform.localScale.y == 1f || (other.transform.localScale.y < 2.1f && other.transform.localScale.y > 1.9f) && !FinAscension)
        {
            switch (Random.Range(0, 12))
            {
                case 4:
                case 5:
                case 6:
                case 7:
                    Objet = Plateforme1;
                    break;
                case 8:
                case 9:
                case 10:
                    Objet = Plateforme2;
                    break;
                case 11:
                    Objet = Plateforme3;
                    break;
                default:
                    Objet = Plateforme4;
                    break;
            }

            Plateforme = Instantiate(Objet);
            NombreEtage++;
            Plateforme.transform.Translate(Random.Range(ObjetP.transform.position.x - 3, ObjetP.transform.position.x + 3), NombreEtage * 1.5f, 0);
            Objet2 = Plateforme;

            //  On translate la nouvelle plateforme à une distance de moins de 5 unités de la dernière et à 8.64 units au dessus de la caméra
            if (Random.Range(0, 6) <= 4)
            {
                Objet2 = Instantiate(Objet);

                Objet2.transform.Translate(Random.Range(ObjetP.transform.position.x - 5, ObjetP.transform.position.x + 5), NombreEtage * 1.5f, 0);

                //  Si la nouvelle plateforme est sur la même ligne et à gauche de la dernière, translate vers la gauche
                if (Objet2.transform.position.x < Objet.transform.position.x)
                    Objet2.transform.Translate(Random.Range(-8, -4), 0, 0);

                //  Si la nouvelle plateforme est sur la même ligne et à froite de la dernière, translate vers la droite
                else if (Objet2.transform.position.x > Objet.transform.position.x)
                    Objet2.transform.Translate(Random.Range(4, 8), 0, 0);

            }

            if (Random.Range(0, 6) <= 3)
            {
                Objet3 = Instantiate(Objet);

                Objet3.transform.Translate(Random.Range(ObjetP.transform.position.x - 5, ObjetP.transform.position.x + 5), NombreEtage * 1.5f, 0);

                //  Si la nouvelle plateforme est sur la même ligne et à gauche de la dernière, translate vers la gauche
                if (Objet3.transform.position.x < Objet.transform.position.x)
                    Objet3.transform.Translate(Random.Range(-8, -4), 0, 0);

                //  Si la nouvelle plateforme est sur la même ligne et à froite de la dernière, translate vers la droite
                else if (Objet3.transform.position.x > Objet.transform.position.x)
                    Objet3.transform.Translate(Random.Range(4, 8), 0, 0);
            }

            if(Random.Range(0, 7) <= 5)
            {
                SpikeInst = Instantiate(Spike);
                SpikeInst.transform.Translate(Random.Range(0, 20), NombreEtage * 1.5f, 0);

                if(Vector2.Distance(SpikeInst.transform.position, Objet.transform.position) < 1 || Vector2.Distance(SpikeInst.transform.position, Objet2.transform.position) < 1
                    || Vector2.Distance(SpikeInst.transform.position, Objet3.transform.position) < 1)
                {
                    SpikeInst.transform.Translate(0, (NombreEtage + 30) * 1.5f, 0);
                }
            }

            //  Si en dehors de l'écran vers la droite, translate vers la gauche
            if (Objet.transform.position.x > 9)
                Objet.transform.Translate(Random.Range(-15, -10), 0, 0);

            //  Si en dehors de l'écran vers la gauche, translate vers la droite
            else if (Objet.transform.position.x < -9)
                Objet.transform.Translate(Random.Range(10, 15), 0, 0);

            //  Si en dehors de l'écran vers la droite, translate vers la gauche
            if (Objet2.transform.position.x > 9)
                Objet2.transform.Translate(Random.Range(-15, -10), 0, 0);

            //  Si en dehors de l'écran vers la gauche, translate vers la droite
            else if (Objet2.transform.position.x < -9)
                Objet2.transform.Translate(Random.Range(10, 15), 0, 0);

            //  Si en dehors de l'écran vers la droite, translate vers la gauche
            if (Objet3.transform.position.x > 9)
                Objet3.transform.Translate(Random.Range(-15, -10), 0, 0);

            //  Si en dehors de l'écran vers la gauche, translate vers la droite
            else if (Objet3.transform.position.x < -9)
                Objet3.transform.Translate(Random.Range(10, 15), 0, 0);
            
            //  On garde en mémoire la dernière plateforme instanciée
            ObjetP = Objet;
        }
    }

    void CreerPlateforme(GameObject objet, GameObject objet2)
    {
        Objet.transform.Translate(Random.Range(ObjetP.transform.position.x - 6, ObjetP.transform.position.x + 6), NombreEtage * 1.5f, 0);

        //  Si en dehors de l'écran vers la droite, translate vers la gauche
        if (Objet.transform.position.x > 9)
            Objet.transform.Translate(Random.Range(-10, -6), 0, 0);

        //  Si en dehors de l'écran vers la gauche, translate vers la droite
        else if (Objet.transform.position.x < -9)
            Objet.transform.Translate(Random.Range(6, 10), 0, 0);
    }
}