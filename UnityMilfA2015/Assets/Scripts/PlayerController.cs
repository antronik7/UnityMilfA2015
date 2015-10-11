using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public bool facingRight = true;
    public float jumpForce = 200f;
    public float spawnForce = 600f;
    public bool standing;
    public float airSpeedMultiplier = 0.5f;
    private Rigidbody2D rb2D;
    public bool changeAirPosition = false;
    public float forceHurtX = 5f;
    public string HoriAxis = "Horizontal";
    public string jumpBouton = "Jump";
    public string fireButton = "Fire1";
    public string nomBall = "Ball1(Clone)";
    public bool Gagner = false;
    public bool disableHurt = false;
    public bool disableMovement = false;
    public string NomSceneWin = "Win1";
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public GameObject spriteAtari;
    public GameObject spawner;
    private GameObject animationLoading;
    private GameObject animatorATrouver;
    public GameObject Atari;
    public GameObject Nes;
    public GameObject Snes;
    public GameObject hurtFeedBack;
    public GameObject Manager;

    private Animator[] animators;

    void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
        animationLoading = transform.Find("loading").gameObject;
    }

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //si sa plante remettre sa en bas
        if (transform.position.y < Camera.main.transform.position.y - 10)
        {
            transform.position = spawner.transform.position;
            Vector2 maForce = new Vector2(0, spawnForce);
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(maForce, ForceMode2D.Force);
            Hurt();
        }

        if(disableMovement)
        {
            return;
        }

        float move = Input.GetAxis(HoriAxis);

        if (!standing && changeAirPosition)
        {
            rb2D.velocity = new Vector2(move * maxSpeed * airSpeedMultiplier, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(move * maxSpeed, rb2D.velocity.y);
        }

        if(move != 0 && standing)
        {
            if (Atari.GetComponent<Animator>().enabled)
            {
                Atari.GetComponent<Animator>().SetInteger("AnimState", 1);
            }

            if (Nes.GetComponent<Animator>().enabled)
            {
                Nes.GetComponent<Animator>().SetInteger("AnimState", 1);
            }

            if (Snes.GetComponent<Animator>().enabled)
            {
                Snes.GetComponent<Animator>().SetInteger("AnimState", 1);
            }

            /*foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 1);
            }*/
        }
        else
        {
            if (Atari.GetComponent<Animator>().enabled)
            {
                Atari.GetComponent<Animator>().SetInteger("AnimState", 0);
            }

            if (Nes.GetComponent<Animator>().enabled)
            {
                Nes.GetComponent<Animator>().SetInteger("AnimState", 0);
            }

            if (Snes.GetComponent<Animator>().enabled)
            {
                Snes.GetComponent<Animator>().SetInteger("AnimState", 0);
            }

            /*foreach (Animator animator in animators)
            {
                if(animator.transform.gameObject.e)
                {
                    animator.SetInteger("AnimState", 0);
                }
            }*/
        }

        if (move > 0 && !facingRight)
        {
            Flip();

            if(!standing)
            {
                changeAirPosition = true;
            }
        }
        else if (move < 0 && facingRight)
        {
            Flip();

            if (!standing)
            {
                changeAirPosition = true;
            }
        }

        

        var absVelY = Mathf.Abs(rb2D.velocity.y);

        if (absVelY < 0.0001f)
        {
            standing = true;
            changeAirPosition = false;

            if (Atari.GetComponent<Animator>().enabled)
            {
                Atari.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            if (Nes.GetComponent<Animator>().enabled)
            {
                Nes.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            if (Snes.GetComponent<Animator>().enabled)
            {
                Snes.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            /*foreach (Animator animator in animators)
            {
                animator.SetBool("AnimStanding", true);
            }*/
        }
        else
        {
            standing = false;
        }

        if (absVelY > 0.5f )
        {
            if (Atari.GetComponent<Animator>().enabled)
            {
                Atari.GetComponent<Animator>().SetInteger("AnimState", 7);
                Atari.GetComponent<Animator>().SetBool("AnimStanding", false);
            }

            if (Nes.GetComponent<Animator>().enabled)
            {
                Nes.GetComponent<Animator>().SetInteger("AnimState", 7);
                Nes.GetComponent<Animator>().SetBool("AnimStanding", false);
            }

            if (Snes.GetComponent<Animator>().enabled)
            {
                Snes.GetComponent<Animator>().SetInteger("AnimState", 7);
                Snes.GetComponent<Animator>().SetBool("AnimStanding", false);
            }

            /*foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 7);
                animator.SetBool("AnimStanding", false);
            }*/
        }
    }

    // Update is called once per frame
    void Update () {

        if(disableMovement)
        {
            return;
        }

        if (standing && Input.GetButtonDown(jumpBouton))
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1f);

            
        }

        if(Gagner)
        {
            Manager.GetComponent<MainMenu>().faireGagner(gameObject.name);
            
            foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 69);
            }
        }

        if(standing)
        {
            if (Atari.GetComponent<Animator>().enabled)
            {
                Atari.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            if (Nes.GetComponent<Animator>().enabled)
            {
                Nes.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            if (Snes.GetComponent<Animator>().enabled)
            {
                Snes.GetComponent<Animator>().SetBool("AnimStanding", true);
            }

            /*foreach (Animator animator in animators)
            {
                animator.SetBool("AnimStanding", true);
            }*/
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        Vector3 childScale = animationLoading.transform.localScale;
        childScale.x *= -1;
        animationLoading.transform.localScale = childScale;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (this.GetComponent<PlayerController>().enabled == false)
        {
            return;
        }
        
        if(!disableHurt)
        {
            if (coll.gameObject.name != nomBall)
            {
                if (coll.gameObject.tag == "Ball")
                {

                    Hurt(coll.transform);

                    Destroy(coll.gameObject);
                }
            }
        }
    }

    public void Hurt(Transform objetHurt)
    {
        if (disableHurt)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(hurtSound, transform.position, 10f);

        foreach (Animator animator in animators)
        {
            animator.SetInteger("AnimState", 5);
        }

        if (objetHurt.position.x > transform.position.x)
        {
            Vector2 maForce = new Vector2(-forceHurtX, 0);
            rb2D.AddForce(maForce, ForceMode2D.Force);
        }
        else
        {
            Vector2 maForce = new Vector2(forceHurtX, 0);
            rb2D.AddForce(maForce, ForceMode2D.Force);
        }

        Instantiate(hurtFeedBack, transform.position, Quaternion.identity);
        GetComponent<PlayerShoot>().munition -= 5;
        GetComponent<PlayerDisable>().DisablePlayer();

        StartCoroutine(disablePlayerHurt());
    }

    public void Hurt()
    {
        AudioSource.PlayClipAtPoint(hurtSound, transform.position, 10f);

        GetComponent<PlayerShoot>().munition -= 5;

        Instantiate(hurtFeedBack, new Vector2(spawner.transform.position.x, spawner.transform.position.y + 3) , Quaternion.identity);
        GetComponent<SpriteFlash>().StartFlashing();
        StartCoroutine(disablePlayerHurt());
    }

    IEnumerator disablePlayerHurt()
    {
        disableHurt = true;

        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);

        disableHurt = false;
    }

    public void StartLoading()
    {
        animationLoading.GetComponent<Animator>().SetTrigger("TriggerLoaging");
    }

    public void initialiserMesControle(int numJoueur)
    {        
        switch (numJoueur)
        { 
            //Joueur 1
            case 1:
                HoriAxis = PlayerPrefs.GetString("1Horizontal");
                jumpBouton = PlayerPrefs.GetString("1Jump");
                fireButton = PlayerPrefs.GetString("1Fire");
                break;
            //Joueur 2
            case 2:
                HoriAxis = PlayerPrefs.GetString("2Horizontal");
                jumpBouton = PlayerPrefs.GetString("2Jump");
                fireButton = PlayerPrefs.GetString("2Fire");
                break;
            //Joueur 3
            case 3:
                HoriAxis = PlayerPrefs.GetString("3Horizontal");
                jumpBouton = PlayerPrefs.GetString("3Jump");
                fireButton = PlayerPrefs.GetString("3Fire");
                break;
            //Joueur 4
            case 4:
                HoriAxis = PlayerPrefs.GetString("4Horizontal");
                jumpBouton = PlayerPrefs.GetString("4Jump");
                fireButton = PlayerPrefs.GetString("4Fire");
                break;
        }
    }
}
