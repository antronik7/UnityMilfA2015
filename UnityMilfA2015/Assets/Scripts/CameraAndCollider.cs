using UnityEngine;
using System.Collections;

public class CameraAndCollider : MonoBehaviour
{
    private Camera Cam;
    private GameObject ObjetInstancie;
    
    public float CameraSpeed;
    public GameObject Pixel;
    public GameObject Plateforme;
    public int HauteurMax;

    void Awake()
    {
        Cam = GetComponentInParent<Camera>();
        CameraSpeed = 3.3f;
    }

    void Update()
    {
        if(Cam.transform.position.y < HauteurMax)
            Cam.transform.Translate(Vector3.up * CameraSpeed * Time.deltaTime);
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);

        if(other.transform.localScale.x > 2)
        {
            ObjetInstancie = Instantiate(Plateforme);
            ObjetInstancie.transform.Translate(Random.Range(-10, 10), Cam.transform.position.y + 8, 0);

            if (Random.Range(0, 4) == 1)
                Instantiate(Pixel).transform.position = ObjetInstancie.transform.position + (Vector3.up * 0.5f);
        }
    }
}