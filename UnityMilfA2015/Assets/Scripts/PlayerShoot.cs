using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject ballPrefab;
    public string fireButton = "Fire1";
    public string vertiAxis = "Vertical";
    public int munition = 20;
    public int munitionPrecedente;
    public int changerAtari = 30;
    public int changerNes = 60;
    public int changerSnes = 90;
    public int munitionVictoire = 100;
    public GameObject spritePixel;
    public GameObject spriteAtari;
    public GameObject spriteNes;
    public GameObject spriteSnes;

    public float timeBetweenShots = 0.3333f;  // Allow 3 shots per second
    public AudioClip shootSound;

    private float timestamp;
    private int nivSprite = 0;

    // Use this for initialization
    void Start () {
        munitionPrecedente = munition;
	}

    // Update is called once per frame
    void Update () {

        if(munition < changerAtari)
        {
            Debug.Log("1");
            if (nivSprite > 0)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 0;
            }

            spritePixel.SetActive(true);
            spriteAtari.GetComponent<Animator>().enabled = false;
            spriteNes.GetComponent<Animator>().enabled = false;
            spriteSnes.GetComponent<Animator>().enabled = false;

            spriteAtari.GetComponent<SpriteRenderer>().sprite = null;
            spriteNes.GetComponent<SpriteRenderer>().sprite = null;
            spriteSnes.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (munition >= changerAtari && munition < changerNes)
        {
            Debug.Log("2");
            if (nivSprite < 1)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 1;

                spritePixel.SetActive(false);
                spriteAtari.GetComponent<Animator>().enabled = true;
                spriteNes.GetComponent<Animator>().enabled = false;
                spriteSnes.GetComponent<Animator>().enabled = false;

                spriteNes.GetComponent<SpriteRenderer>().sprite = null;
                spriteSnes.GetComponent<SpriteRenderer>().sprite = null;

            }

            if (nivSprite > 1)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 1;

                spritePixel.SetActive(false);
                spriteAtari.GetComponent<Animator>().enabled = true;
                spriteNes.GetComponent<Animator>().enabled = false;
                spriteSnes.GetComponent<Animator>().enabled = false;


                spriteNes.GetComponent<SpriteRenderer>().sprite = null;
                spriteSnes.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        else if (munition >= changerNes && munition < changerSnes)
        {
            Debug.Log("3");
            if (nivSprite < 2)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 2;

                spritePixel.SetActive(false);
                spriteAtari.GetComponent<Animator>().enabled = false;
                spriteNes.GetComponent<Animator>().enabled = true;
                spriteSnes.GetComponent<Animator>().enabled = false;

                spriteAtari.GetComponent<SpriteRenderer>().sprite = null;
                spriteSnes.GetComponent<SpriteRenderer>().sprite = null;
            }

            if (nivSprite > 2)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 2;

                spritePixel.SetActive(false);
                spriteAtari.GetComponent<Animator>().enabled = false;
                spriteNes.GetComponent<Animator>().enabled = true;
                spriteSnes.GetComponent<Animator>().enabled = false;

                spriteAtari.GetComponent<SpriteRenderer>().sprite = null;
                spriteSnes.GetComponent<SpriteRenderer>().sprite = null;
            }

        }
        else if (munition >= changerSnes)
        {
            Debug.Log("4");
            if (nivSprite < 3)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 3;
            }

            spritePixel.SetActive(false);
            spriteAtari.GetComponent<Animator>().enabled = false;
            spriteNes.GetComponent<Animator>().enabled = false;
            spriteSnes.GetComponent<Animator>().enabled = true;

            spriteAtari.GetComponent<SpriteRenderer>().sprite = null;
            spriteNes.GetComponent<SpriteRenderer>().sprite = null;

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

                if (spriteAtari.GetComponent<Animator>().enabled)
                {
                    spriteAtari.GetComponent<Animator>().SetInteger("AnimState", 3);
                }

                if (spriteNes.GetComponent<Animator>().enabled)
                {
                    spriteNes.GetComponent<Animator>().SetInteger("AnimState", 3);
                }

                if (spriteSnes.GetComponent<Animator>().enabled)
                {
                    spriteSnes.GetComponent<Animator>().SetInteger("AnimState", 3);
                }

            }
            else if (move < -0.45)
            {
                dirY = -1;

                if (spriteAtari.GetComponent<Animator>().enabled)
                {
                    spriteAtari.GetComponent<Animator>().SetInteger("AnimState", 4);
                }

                if (spriteNes.GetComponent<Animator>().enabled)
                {
                    spriteNes.GetComponent<Animator>().SetInteger("AnimState", 4);
                }

                if (spriteSnes.GetComponent<Animator>().enabled)
                {
                    spriteSnes.GetComponent<Animator>().SetInteger("AnimState", 4);
                }

            }
            else if (transform.localScale.x > 0)
            {
                dirX = 1;

                if (spriteAtari.GetComponent<Animator>().enabled)
                {
                    spriteAtari.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

                if (spriteNes.GetComponent<Animator>().enabled)
                {
                    spriteNes.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

                if (spriteSnes.GetComponent<Animator>().enabled)
                {
                    spriteSnes.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

            }
            else if (transform.localScale.x < 0)
            {
                dirX = -1;

                if (spriteAtari.GetComponent<Animator>().enabled)
                {
                    spriteAtari.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

                if (spriteNes.GetComponent<Animator>().enabled)
                {
                    spriteNes.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

                if (spriteSnes.GetComponent<Animator>().enabled)
                {
                    spriteSnes.GetComponent<Animator>().SetInteger("AnimState", 2);
                }

            }

            ball.GetComponent<BallController>().Initialize(dirX, dirY);
            timestamp = Time.time + timeBetweenShots;

            munition--;
        }

        if(munition < 0)
        {
            munition = 0;
        }
        else if (munition >= munitionVictoire)
        {
            GetComponent<PlayerController>().Gagner = true;
        }

        
    }
}
