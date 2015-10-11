using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.GetComponent<PlayerController>().disableHurt)
            other.GetComponent<PlayerController>().Hurt();
    }
}
