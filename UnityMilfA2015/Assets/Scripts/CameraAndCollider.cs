using UnityEngine;
using System.Collections;

public class CameraAndCollider : MonoBehaviour
{
    private Camera Cam;
    
    public float CameraSpeed;
    public GameObject Prefab;
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
        Instantiate(Prefab).transform.Translate(Random.Range(-7, 7), Cam.transform.position.y + 8, 0);
    }
}