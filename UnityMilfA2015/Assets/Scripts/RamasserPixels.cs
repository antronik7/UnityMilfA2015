using UnityEngine;
using System.Collections;

public class RamasserPixels : MonoBehaviour 
{
    private PlayerShoot Script;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Substring(0, 6) == "Player")
        {
            Script = other.GetComponent<PlayerShoot>();
            Script.munition += 10;
            Destroy(this.gameObject);
        }
    }
}