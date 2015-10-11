using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject ballPrefab;
    public string fireButton = "Fire1";
    public string vertiAxis = "Vertical";
    public int munition = 20;
    public int munitionPrecedente;
    public int changerAtari;
    public int changerNes = 60;
    public GameObject spritePixel;
    public GameObject spriteAtari;
    public GameObject spriteNes;

    public float timeBetweenShots = 0.3333f;  // Allow 3 shots per second
    public AudioClip shootSound;

    private SpriteRenderer[] sprites;
    private float timestamp;
    private int nivSprite = 0;
    private Animator[] animators;

    // Use this for initialization
    void Start () {
        munitionPrecedente = munition;
        sprites = GetComponentsInChildren<SpriteRenderer>();
	}
    void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update () {

        if(munition < changerAtari)
        {
            if (nivSprite > 0)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 0;
            }
                
            //GetComponentsInChildren<PlayerController>();
            spritePixel.SetActive(true);
            spriteAtari.SetActive(false);
            spriteNes.SetActive(false);
        }
        else if (munition >= changerAtari)
        {
            if (nivSprite < 1)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 1;

                spritePixel.SetActive(false);
                spriteAtari.SetActive(true);
                spriteNes.SetActive(false);
            }
            else if(nivSprite < 2)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 1;

                spritePixel.SetActive(false);
                spriteAtari.SetActive(true);
                spriteNes.SetActive(false);
            }

            spritePixel.SetActive(false);
            spriteAtari.SetActive(true);
            spriteNes.SetActive(false);
        }

        else if (munition >= changerNes)
        {
            if (nivSprite < 2)
            {
                GetComponent<PlayerController>().StartLoading();
                nivSprite = 2;
            }

            spritePixel.SetActive(false);
            spriteAtari.SetActive(true);
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

                foreach (Animator animator in animators)
                {
                    animator.SetInteger("AnimState", 3);
                }
            }
            else if (move < -0.45)
            {
                dirY = -1;

                foreach (Animator animator in animators)
                {
                    animator.SetInteger("AnimState", 4);
                }
            }
            else if (transform.localScale.x > 0)
            {
                dirX = 1;

                foreach (Animator animator in animators)
                {
                    animator.SetInteger("AnimState", 2);
                }
            }
            else if (transform.localScale.x < 0)
            {
                dirX = -1;

                foreach (Animator animator in animators)
                {
                    animator.SetInteger("AnimState", 2);
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
        else if (munition >= 100)
        {
            GetComponent<PlayerController>().Gagner = true;
        }

        
    }
}
