using UnityEngine;
using System.Collections;

public class RamasserPixels : MonoBehaviour 
{
    private PlayerShoot Script;
    public GameObject[] hurtFeedBack;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Substring(0, 6) == "Player")
        {
            Script = other.GetComponent<PlayerShoot>();

            if (this.gameObject.name == "Munition1(Clone)")
                Script.munition++;
            if (this.gameObject.name == "Munition5(Clone)")
                Script.munition += 5;
            if (this.gameObject.name == "Munition10(Clone)")
                Script.munition += 10;

            Destroy(this.gameObject);
        }
    }
}