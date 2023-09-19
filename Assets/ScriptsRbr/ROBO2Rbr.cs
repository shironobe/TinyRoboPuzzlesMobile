using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ROBO2Rbr : MonoBehaviour
{
    public static ROBO2Rbr instance;
    public LayerMask BlockMask = 0;
    public float detectionRadius;
    private Vector3 Destination;
    public float speed;

    public Animator robo2Anim;

    public bool Mobile;
   

    public bool Pressed;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        robo2Anim  = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    CheckDirection(Vector3.left);
        //    robo2Anim.SetBool("Left", true);
        //    AudioManager.instance.PlaySfx(1);

        //}
        //else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    CheckDirection(Vector3.right);
        //    robo2Anim.SetBool("Right", true);
        //    AudioManager.instance.PlaySfx(1);
        //}
        //else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    CheckDirection(Vector3.down);
        //    CheckDirection(Vector3.up);
        //    robo2Anim.SetBool("Down", true);
        //    AudioManager.instance.PlaySfx(1);
        //}
        //else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    //CheckDirection(Vector3.up);
        //    CheckDirection(Vector3.down);
        //    robo2Anim.SetBool("Up", true);
        //    AudioManager.instance.PlaySfx(1);
        //}



        if (!ManagerRbr.instance.Mobile)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {


                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    CheckDirection(Vector3.right);
                    robo2Anim.SetBool("Right", true);
                    AudioManagerRbr.instance.PlaySfx(1);
                }


            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    CheckDirection(Vector3.left);
                    robo2Anim.SetBool("Left", true);
                    AudioManagerRbr.instance.PlaySfx(1);
                }
                // AudioManager.instance.PlaySfx(1);

            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    CheckDirection(Vector3.up);
                    robo2Anim.SetBool("Up", true);
                    AudioManagerRbr.instance.PlaySfx(1);
                }


            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    CheckDirection(Vector3.down);
                    robo2Anim.SetBool("Down", true);
                    AudioManagerRbr.instance.PlaySfx(1);
                }

            }
            else
            {
                if (!pressed)
                {
                    robo2Anim.SetBool("Down", false);
                    robo2Anim.SetBool("Up", false);
                    robo2Anim.SetBool("Left", false);
                    robo2Anim.SetBool("Right", false);
                }
            }
        }
    }


    public void UpmagnetUse()
    {
        CheckDirection(Vector3.up);
        robo2Anim.SetBool("Up", true);
        StartCoroutine(MagnetUse());
        AudioManagerRbr.instance.PlaySfx(1);
    }
    public void DownmagnetUse()
    {
        CheckDirection(Vector3.down);
        robo2Anim.SetBool("Down", true);
        StartCoroutine(MagnetUse());
        AudioManagerRbr.instance.PlaySfx(1);
    }

    public void RightmagnetUse()
    {
        CheckDirection(Vector3.right);
        robo2Anim.SetBool("Right", true);
        StartCoroutine(MagnetUse());
        AudioManagerRbr.instance.PlaySfx(1);
    }

    
    public void LeftmagnetUse()
    {
        CheckDirection(Vector3.left);
        robo2Anim.SetBool("Left", true);
        StartCoroutine(MagnetUse());
        AudioManagerRbr.instance.PlaySfx(1);
    }
    public bool pressed;
    public void Up()
    {

        

        if (!pressed)
        {
            UpMangent();
            pressed = true;
        }
        else
        {
            pressed = false;
        }

    }

  
    public bool UpMangent()
    {
        if (pressed)
        {
           
            CheckDirection(Vector3.up);
            robo2Anim.SetBool("Up", true);
            AudioManagerRbr.instance.PlaySfx(1);
           

            return false;
        }
        else
            return false;

    }


    IEnumerator MagnetUse()
    {
        pressed = true;
        yield return new WaitForSeconds(0.1f);
        pressed = false;
    }
    private bool CheckDirection(Vector3 direction)
    {
        //{
        //    Ray2D Ray = new Ray2D(transform.position, direction);

        //    RaycastHit2D hit;
       
      // Hole.instance.OffCollider();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);

        Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
        //  Debug.DrawRay(hit1pos.transform.position, direction);

        if (hit)
        {
            string tag = hit.transform.tag;

           // Debug.Log(Vector3.Distance(transform.position, hit.transform.position));
            
                if (hit.collider.gameObject.CompareTag("Pushable") || hit.collider.gameObject.CompareTag("PushableWoodBlock") )
                {

                PushableBlockRbr pushableBlock = hit.collider.GetComponent<PushableBlockRbr>();


                if (!pushableBlock)
                    return false;


                pushableBlock.Hook(direction, speed);


             //  Hole.instance.OnCollider();


            }
            
            return false;
        }

       
        return true;
    }



}
