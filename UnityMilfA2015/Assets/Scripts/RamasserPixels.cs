using UnityEngine;
using System.Collections;

public class RamasserPixels : MonoBehaviour 
{
    private PlayerShoot Script;
    public GameObject[] pickUPFeedBack;
    public AudioClip pickUpSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Substring(0, 6) == "Player")
        {
            Script = other.GetComponent<PlayerShoot>();

            if (this.gameObject.name == "Munition1(Clone)")
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 10f);
                Instantiate(pickUPFeedBack[0], transform.position, Quaternion.identity);
                Script.munition++;
            }
            Script.munition++;
            if (this.gameObject.name == "Munition5(Clone)")
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 10f);
                Instantiate(pickUPFeedBack[1], transform.position, Quaternion.identity);
                Script.munition += 5;
            }
                
            if (this.gameObject.name == "Munition10(Clone)")
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 10f);
                Instantiate(pickUPFeedBack[2], transform.position, Quaternion.identity);
                Script.munition += 10;
            }
                

            Destroy(this.gameObject);
        }
    }
}