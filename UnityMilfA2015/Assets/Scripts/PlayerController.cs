using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public bool facingRight = true;
    public float jumpForce = 200f;
    public float spawnForce = 600f;
    public bool standing;
    public float airSpeedMultiplier = 0.5f;
    public Rigidbody2D rb2D;
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
    public GameObject spriteAtari;
    public GameObject spawner;

    private Animator[] animators;


    void Awake()
    {
        animators = GetComponentsInChildren<Animator>();
    }

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        spriteAtari.SetActive(false);
    }

    void FixedUpdate()
    {
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
            foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 1);
            }
        }
        else
        {
            foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 0);
            }
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

        if(transform.position.y < -10)
        {
            transform.position = spawner.transform.position;
            Vector2 maForce = new Vector2(0, spawnForce);
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(maForce, ForceMode2D.Force);
            GetComponent<SpriteFlash>().StartFlashing();
            StartCoroutine(disablePlayerHurt());
        }

    }

    // Update is called once per frame
    void Update () {
        var absVelY = Mathf.Abs(rb2D.velocity.y);

        if (absVelY < 0.0001f)
        {
            standing = true;
            changeAirPosition = false;
        }
        else
        {
            standing = false;
        }

        if (standing && Input.GetButtonDown(jumpBouton))
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1f);
        }

        if(Input.GetButtonDown(fireButton))
        {
            foreach (Animator animator in animators)
            {
                animator.SetInteger("AnimState", 2);
            }
        }

        if(Gagner)
        {
            Application.LoadLevel(NomSceneWin);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        /*if (this.GetComponent<PlayerController>().enabled == false)
        {
            return;
        }*/
        
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

    void Hurt(Transform objetHurt)
    {
        if(objetHurt.position.x > transform.position.x)
        {
            Vector2 maForce = new Vector2(-forceHurtX, 0);
            rb2D.AddForce(maForce, ForceMode2D.Force);
        }
        else
        {
            Vector2 maForce = new Vector2(forceHurtX, 0);
            rb2D.AddForce(maForce, ForceMode2D.Force);
        }

        GetComponent<PlayerShoot>().munition -= 10;
        GetComponent<PlayerDisable>().DisablePlayer();

        StartCoroutine(disablePlayerHurt());
    }

    IEnumerator disablePlayerHurt()
    {
        disableHurt = true;

        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);

        disableHurt = false;
    }
}
