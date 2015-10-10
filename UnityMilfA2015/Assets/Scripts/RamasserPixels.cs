using UnityEngine;
using System.Collections;

public class RamasserPixels : MonoBehaviour 
{
    private PlayerShoot Script;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name != "Collider" && other.name != "Pixel(Clone)" && other.name != "Ball1(Clone)")
        {
            Script = other.GetComponent<PlayerShoot>();
            Script.munition += 10;
            Destroy(this.gameObject);
        }
    }
}