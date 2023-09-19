using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerRt : MonoBehaviour
{
    public Rigidbody2D theRb;


    public static PlayerControllerRt instance;

    [SerializeField] public float moveSpeed;

    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    //bool canDoubleJump;

    SpriteRenderer Sr;
    float Move;

    Animator anim;
    public bool canMove;
    Animator SceneTransition;
    Animator Robo2anim;
    //public bool isDashing;
    //public float startdashTime;
    //float dashTime;
    //public float direction;
    //public float dashDistance;

    bool movingRight, movingLeft;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
        canMove = true;
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
        Robo2anim = GameObject.FindGameObjectWithTag("Robo2").GetComponent<Animator>();
        //  dashTime = startdashTime;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //  Debug.Log("FixedUpdate time :" + Time.deltaTime);
        //if (isDashing)
        //{
        //    float Gravity = theRb.gravityScale;
        //    theRb.gravityScale = 0f;
        //    theRb.velocity = Vector2.right * direction * dashDistance;
        //    Debug.Log("here");
        //    // theRb.velocity = Vector2.left * direction * dashDistance;
        //    dashTime -= Time.deltaTime;
        //    if (dashTime <= 0)
        //    {
        //        theRb.gravityScale = 2f;
        //        isDashing = false;

        //        // canMove = true;
        //    }
        //}


        //if (theRb.bodyType != RigidbodyType2D.Static && !isDashing)
        //{
        //    theRb.velocity = new Vector2(moveSpeed * Move, theRb.velocity.y);
        //}
        //void jump()
        //{
        //    if (isGrounded)
        //    {
        //        // CreateDust();
        //        theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
        //    }
        //    else
        //    {
        //        if (canDoubleJump)
        //        {
        //            theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
        //            canDoubleJump = false;
        //        }
        //    }
        //}

    }
    void Update()
    {
        //  Debug.Log("Update time :" + Time.deltaTime);






        if (canMove)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || movingRight /*&& !isDashing*/)
            {
                // theRb.AddForce(Vector2.right);
                Move = 1;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || movingLeft/* && !isDashing*/)
            {
                // theRb.AddForce(Vector2.left);
                Move = -1;
            }

            else
            {

                Move = Mathf.Lerp(Move, 0, 2f);

            }


            if (theRb.bodyType != RigidbodyType2D.Static/* && !isDashing*/)
            {
                theRb.velocity = new Vector2(moveSpeed * Move, theRb.velocity.y);
            }
            anim.SetFloat("moveSpeed", Mathf.Abs(theRb.velocity.x));
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.15f, whatIsGround);

            //if (isGrounded)
            //{
            //    canDoubleJump = true;
            //}

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    // CreateDust();
                    AudioManagerRt.instance.PlaySfx(2);
                    theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
                }
                //else
                //{
                //    if (canDoubleJump)
                //    {
                //        theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
                //        canDoubleJump = false;
                //    }
                //}

                //if (theRb.velocity.y < 0)
                //{
                //   // theRb.gravityScale = 6.5f;
                //}
            }

            if (theRb.velocity.x > 0 /*&& !isDashing*/)
            {
                Sr.flipX = false;
            }
            else
            {
                if (theRb.velocity.x < 0 /*&& !isDashing*/)
                {
                    Sr.flipX = true;
                }
            }
        }
    }


    public void MoveRight()
    {
        if (canMove)
        {
            movingRight = true;
        }
    }

    public void MoveRightUp()
    {
        if (canMove)
        {
            movingRight = false;
        }
    }

    public void MoveLeft()
    {
        if (canMove)
        {
            movingLeft = true;
        }
    }
    public void MoveLeftUp()
    {
        if (canMove)
        {
            movingLeft = false;
        }
    }

    public void Jump()
    {
        
        
            if (isGrounded && canMove)
        {
            // CreateDust();
            AudioManagerRt.instance.PlaySfx(2);
            theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            AudioManagerRt.instance.PlaySfx(7);
            //win
            if (isGrounded)
            {
                theRb.velocity = Vector2.zero;
                canMove = false;
                // theRb.velocity = Vector2.zero;
                anim.SetTrigger("finish");
                Robo2anim.SetTrigger("finish");
                StartCoroutine(NextLevel());
                if (PlayerPrefs.GetInt("LevelUnlockRobotwins") < SceneManager.GetActiveScene().buildIndex + 1)
           {
               PlayerPrefs.SetInt("LevelUnlockRobotwins", SceneManager.GetActiveScene().buildIndex + 1 -65);
          }

            }
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            if (isGrounded)
            {
              
                theRb.velocity = Vector2.zero;
                canMove = false;
                // theRb.velocity = Vector2.zero;
                anim.SetTrigger("finish");
                Robo2anim.SetTrigger("finish");
              
                StartCoroutine(NextLevel());

               
            }


        }
    }
    
  


    IEnumerator NextLevel()
    {

       
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(1.3f);

        SceneTransition.SetTrigger("end");

        if (SceneManager.GetActiveScene().buildIndex == 89)
        {
            SceneManager.LoadScene(94);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


    //IEnumerator Dash(float direction)
    //{
    //    isDashing = true;
    //    theRb.velocity = new Vector2(theRb.velocity.x, 0f);
    //    theRb.gravityScale = 0f;
    //    theRb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
    //    yield return new WaitForSeconds(0.3f);
    //    theRb.gravityScale = 2f;
    //    isDashing = false;

    //}
}
