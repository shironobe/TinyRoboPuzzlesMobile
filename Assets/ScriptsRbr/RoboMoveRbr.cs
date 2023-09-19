using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoboMoveRbr : MonoBehaviour
{
    public static RoboMoveRbr instance;

   // public ParticleSystem Dust;

    public Rigidbody2D theRb;

    public float moveSpeed;

    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public Animator anim;

    public bool canSwitch;
                                         
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        theRb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
               // CreateDust();
                theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
            }
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(theRb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1.7f, 1.7f);
        }
        else
        {
            if(theRb.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1.7f, 1.7f);
            }
        }

        anim.SetFloat("movespeed",Mathf.Abs( theRb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robo2"))
        {
            canSwitch = false;
        }
        else
        {
            canSwitch = true;
        }
    }

    //void CreateDust()
    //{
    //    Dust.Play();
    //}

}
