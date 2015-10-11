using UnityEngine;
using System.Collections;

public class Hurt5Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyThisAnimation()
    {
        Destroy(gameObject);
    }
}
