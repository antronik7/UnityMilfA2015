using UnityEngine;
using System.Collections;

public class PlayerDisable : MonoBehaviour {

    public float waitSeconds = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisablePlayer()
    {
        StartCoroutine("DisableScripts");
    }

    IEnumerator DisableScripts()
    {
        transform.GetComponent<PlayerController>().enabled = false;
        transform.GetComponent<PlayerShoot>().enabled = false;

        yield return new WaitForSeconds(waitSeconds);

        transform.GetComponent<PlayerController>().enabled = true;
        transform.GetComponent<PlayerShoot>().enabled = true;

    }
}
