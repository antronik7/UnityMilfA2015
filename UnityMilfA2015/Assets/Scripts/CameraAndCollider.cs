using UnityEngine;
using System.Collections;

public class CameraAndCollider : MonoBehaviour
{
    private bool FinAscension;
    private Camera Cam;
    private GameObject ObjetInstancie;
    private MainMenu Menu;
    private GameObject Plateforme;
    
    public GameObject ObjetInstanciePrecedent;
    public GameObject ScriptMenu;
    public float CameraSpeed;
    public GameObject Pixel;
    
    public int HauteurMax;

    void Awake()
    {
        Cam = GetComponentInParent<Camera>();
        CameraSpeed = 1f;
        FinAscension = false;
        Menu = ScriptMenu.GetComponent<MainMenu>();
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        
        if(other.transform.localScale.y < 0.5 && !FinAscension)
        {
            switch(Random.Range(0,3))
            {
                case 0:
                    Plateforme = (GameObject)Resources.Load("Plateforme3");
                    break;
                case 1:
                case 2:
                    Plateforme = (GameObject)Resources.Load("Plateforme4");
                    break;
                case 3:
                    Plateforme = (GameObject)Resources.Load("Plateforme5");
                    break;
            }
            ObjetInstancie = Instantiate(Plateforme);

            ObjetInstancie.transform.Translate(Random.Range(ObjetInstanciePrecedent.transform.position.x - 7,
                ObjetInstanciePrecedent.transform.position.x + 7), Cam.transform.position.y + 8.64f, 0);
            
            if(ObjetInstancie.transform.position.x > 10)
                ObjetInstancie.transform.Translate(Random.Range(-8, -4), 0, 0);

            else if (ObjetInstancie.transform.position.x < -10)
                ObjetInstancie.transform.Translate(Random.Range(4, 8), 0, 0);

            if (Random.Range(0, 5) == 1)
                Instantiate(Pixel).transform.position = ObjetInstancie.transform.position + (Vector3.up * 0.5f);

            ObjetInstanciePrecedent = ObjetInstancie;       
        }
    }

    void TerminerAscension()
    {
            
    }
}