using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject ballPrefab;
    public string fireButton = "Fire1";
    public string vertiAxis = "Vertical";
    public int munition = 20;
    public int munitionPrecedente;
    public int changerAtari;
    public GameObject spritePixel;
    public GameObject spriteAtari;

    public float timeBetweenShots = 0.3333f;  // Allow 3 shots per second
    public AudioClip shootSound;

    private SpriteRenderer[] sprites;
    private float timestamp;

    // Use this for initialization
    void Start () {
        munitionPrecedente = munition;
        sprites = GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if(munitionPrecedente != munition)
        {
            if(munition < changerAtari)
            {
                //Play Animation
                spritePixel.SetActive(true);
                spriteAtari.SetActive(false);
            }
            else if (munition >= changerAtari)
            {
                //Play Animation
                spritePixel.SetActive(false);
                spriteAtari.SetActive(true);
            }
        }

        if (Time.time >= timestamp && Input.GetButtonDown(fireButton) && munition >= 1)
        {
            float move = Input.GetAxis(vertiAxis);

            GameObject ball = Object.Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(shootSound, transform.position, 1f);

            int dirX = 0;
            int dirY = 0;

            if (move > 0.45)
            {
                dirY = 1;
            }
            else if (move < -0.45)
            {
                dirY = -1;
            }
            else if (transform.localScale.x > 0)
            {
                dirX = 1;
            }
            else if (transform.localScale.x < 0)
            {
                dirX = -1;
            }

            ball.GetComponent<BallController>().Initialize(dirX, dirY);
            timestamp = Time.time + timeBetweenShots;

            munition--;
        }

        if(munition < 0)
        {
            munition = 0;
        }
        else if (munition >= 100)
        {
            GetComponent<PlayerController>().Gagner = true;
        }

        munitionPrecedente = munition;
    }
}
