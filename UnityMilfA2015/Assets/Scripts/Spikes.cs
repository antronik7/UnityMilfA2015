using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>().Hurt(transform);
    }
}
