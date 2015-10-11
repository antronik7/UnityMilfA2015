using UnityEngine;
using System.Collections;

public class ScriptBeam : MonoBehaviour {

    private bool ToucherJoueur = false;
    public string nameGagnant;

    private GameObject joueurGagant;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(ToucherJoueur)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + 50), 3 * Time.deltaTime);
            joueurGagant.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + 50), 3 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y - 50), 3 * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == nameGagnant)
        {
            joueurGagant = coll.gameObject;
            ToucherJoueur = true;
        }
    }
}
