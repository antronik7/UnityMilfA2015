using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public int speedBullet = 6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.x) > Camera.main.transform.position.x + 20 || Mathf.Abs(transform.position.y) > Camera.main.transform.position.y + 20)
        {
            Destroy(gameObject);
        }
	}

    public void Initialize(int dirX, int dirY)
    {
        if(dirX != 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (speedBullet * dirX, dirY);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(dirX, speedBullet * dirY);
        }
    }

}
