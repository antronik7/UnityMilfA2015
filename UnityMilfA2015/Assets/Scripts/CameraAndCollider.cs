using UnityEngine;
using System.Collections;

public class CameraAndCollider : MonoBehaviour
{
    private GameObject Mur;
    private bool FinAscension;
    private Camera Cam;
    private GameObject Objet;
    private MainMenu Menu;
    private GameObject Plateforme;
    
    public GameObject ObjetP;
    public GameObject ScriptMenu;
    public float CameraSpeed;
    public GameObject Pixel;

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

        if(Cam.orthographic)
        {
            Scale = Screen.height / NativeResolution.y;
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Player1" && other.gameObject.name != "Player2" && other.gameObject.name != "Player3" && other.gameObject.name != "Player4")
            Destroy(other.gameObject);
        
        if(other.transform.localScale.y < 0.5 && !FinAscension)
        {
            switch(Random.Range(0,12))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    Plateforme = (GameObject)Resources.Load("Plateforme3");
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                    Plateforme = (GameObject)Resources.Load("Plateforme4");
                    break;
                case 8:
                case 9:
                case 10:
                    Plateforme = (GameObject)Resources.Load("Plateforme5");
                    break;
                case 11:
                    Plateforme = (GameObject)Resources.Load("Plateforme15");
                    break;
            }

            //  On instancie une nouvelle plateforme
            Objet = Instantiate(Plateforme);

            //  On translate la nouvelle plateforme à une distance de moins de 5 unités de la dernière et à 8.64 units au dessus de la caméra
            Objet.transform.Translate(Random.Range(ObjetP.transform.position.x - 4,
                ObjetP.transform.position.x + 4), Cam.transform.position.y + 8.64f, 0);

            //  Si la nouvelle plateforme est sur la même ligne et à gauche de la dernière, translate vers la gauche
            if (Objet.transform.position.y == ObjetP.transform.position.y && Objet.transform.position.x < ObjetP.transform.position.x)
                Objet.transform.Translate(Random.Range(-6, -2), 0, 0);

            //  Si la nouvelle plateforme est sur la même ligne et à froite de la dernière, translate vers la droite
            else if (Objet.transform.position.y == ObjetP.transform.position.y && Objet.transform.position.x > ObjetP.transform.position.x)
                Objet.transform.Translate(Random.Range(2, 6), 0, 0);

            //  Si en dehors de l'écran vers la droite, translate vers la gauche
            if (Objet.transform.position.x > 9)
                Objet.transform.Translate(Random.Range(-10, -6), 0, 0);

            //  Si en dehors de l'écran vers la gauche, translate vers la droite
            else if (Objet.transform.position.x < -9)
                Objet.transform.Translate(Random.Range(6, 10), 0, 0);

            //  1 chance sur 5 d'instancier un Pixel
            if (Random.Range(0, 5) == 1)
                Instantiate(Pixel).transform.position = Objet.transform.position + (Vector3.up * 0.5f);
            
            //  On garde en mémoire la dernière plateforme instanciée
            ObjetP = Objet;       
        }
    }

    void TerminerAscension()
    {
            
    }
}