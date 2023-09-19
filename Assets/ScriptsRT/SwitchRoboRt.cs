using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SwitchRoboRt : MonoBehaviour
{
    public GameObject Robo1, Robo2;


    public SpriteRenderer sr;

    public Sprite on, off;

    public bool isPressed;

    public Sprite PoleOn, PoleOff;


    public PoleRt[] Poles;
    public SpriteRenderer PoleRobo2;

    public Sprite Robo1On, Robo1Off, Robo2On, Robo2Off;

    public static SwitchRoboRt instance;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Robo1 = GameObject.FindGameObjectWithTag("Robo1");

        Robo2 = GameObject.FindGameObjectWithTag("Robo2");

        sr = GetComponent<SpriteRenderer>();

        Poles = FindObjectsOfType<PoleRt>();

        //PoleRobo1 = GameObject.FindGameObjectWithTag("PoleRobo1").GetComponent<SpriteRenderer>();

        PoleRobo2 = GameObject.FindGameObjectWithTag("PoleRobo2").GetComponent<SpriteRenderer>();

       
    }

    // Update is called once per frame
    void Update()
    {

        if(Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            Robo2.GetComponent<SpriteRenderer>().sprite = Robo2Off;
        }



        if (Input.GetKeyDown(KeyCode.Space) && isPressed && RoboControllerRt.instance.isMoving == false)
        {

             if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
                {
                AudioManagerRt.instance.PlaySfx(4);
                PlayerControllerRt.instance.canMove = false;
                PlayerControllerRt.instance.theRb.velocity = Vector2.zero;
                   Robo1.GetComponent<PlayerControllerRt>().enabled = false;

                    Robo2.GetComponent<RoboControllerRt>().enabled = true;

                    // PoleRobo1.sprite = PoleOff;
                   
                    PoleRobo2.sprite = PoleOn;
               
                // Robo1.GetComponent<SpriteRenderer>().sprite = Robo1Off;
                for (int i = 0; i < Poles.Length; i++)
                    {
                        Poles[i].PoleRobo1.sprite = PoleOff;

                    
                       
                    
                }


                    Robo1.GetComponent<Animator>().SetBool("Off", true);
                    Robo2.GetComponent<SpriteRenderer>().sprite = Robo2On;


                }
                else
                {
                    if (Robo1.GetComponent<PlayerControllerRt>().enabled == false)
                    {
                    AudioManagerRt.instance.PlaySfx(4);
                    PlayerControllerRt.instance.canMove = true;
                    Robo1.GetComponent<PlayerControllerRt>().enabled = true;

                        Robo2.GetComponent<RoboControllerRt>().enabled = false;




                        PoleRobo2.sprite = PoleOff;


                        Robo1.GetComponent<Animator>().SetBool("Off", false);
                        //  Robo1.GetComponent<SpriteRenderer>().sprite = Robo1On;

                        Robo2.GetComponent<SpriteRenderer>().sprite = Robo2Off;
                    }

                }
           
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
         
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CommandInvoker.instance.ResetCounter();
        }
    }



    public void MoveUp()
    {

        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            PlayerControllerRt.instance.Jump();
        }
        else
        {
            RoboControllerRt.instance.MoveUp();
        }
    }

    public void MoveDown()
    {

        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            //DO nothing
        }
        else
        {
            RoboControllerRt.instance.MoveDown();
        }
    }

    public void MoveRight()
    {

        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            PlayerControllerRt.instance.MoveRight();
        }
        else
        {
            RoboControllerRt.instance.MoveRight();
        }
    }

    public void RightButtonUp()
    {
        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            PlayerControllerRt.instance.MoveRightUp();
        }
       
    }

    public void MoveLeft()
    {
        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            PlayerControllerRt.instance.MoveLeft();
        }
        else
        {
            RoboControllerRt.instance.MoveLeft();
        }
    }

   
    public void LeftButtonUp()
    {
        if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            PlayerControllerRt.instance.MoveLeftUp();
        }
    }


    public void Undo()
    {
        CommandInvoker.instance.undo();
    }

   
    public void SwitchRobo()
    {
        if(isPressed && RoboControllerRt.instance.isMoving == false)
        {
            if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
            {
                AudioManagerRt.instance.PlaySfx(4);
                PlayerControllerRt.instance.canMove = false;
                PlayerControllerRt.instance.theRb.velocity = Vector2.zero;
                Robo1.GetComponent<PlayerControllerRt>().enabled = false;

                Robo2.GetComponent<RoboControllerRt>().enabled = true;

                // PoleRobo1.sprite = PoleOff;

                PoleRobo2.sprite = PoleOn;

                // Robo1.GetComponent<SpriteRenderer>().sprite = Robo1Off;
                for (int i = 0; i < Poles.Length; i++)
                {
                    Poles[i].PoleRobo1.sprite = PoleOff;




                }


                Robo1.GetComponent<Animator>().SetBool("Off", true);
                Robo2.GetComponent<SpriteRenderer>().sprite = Robo2On;


            }
            else
            {
                if (Robo1.GetComponent<PlayerControllerRt>().enabled == false)
                {
                    AudioManagerRt.instance.PlaySfx(4);
                    PlayerControllerRt.instance.canMove = true;
                    Robo1.GetComponent<PlayerControllerRt>().enabled = true;

                    Robo2.GetComponent<RoboControllerRt>().enabled = false;




                    PoleRobo2.sprite = PoleOff;


                    Robo1.GetComponent<Animator>().SetBool("Off", false);
                    //  Robo1.GetComponent<SpriteRenderer>().sprite = Robo1On;

                    Robo2.GetComponent<SpriteRenderer>().sprite = Robo2Off;
                }

            }

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1") && Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            sr.sprite = on;
            isPressed = true;

           if(Robo1.GetComponent<PlayerControllerRt>().enabled == true)
            {
               // PoleRobo1.sprite = PoleOn;
            }
            //if (Input.GetKeyDown(KeyCode.Space) && Robo1.GetComponent<PlayerController>().enabled == true)
            //{
               
            //    Robo1.GetComponent<PlayerController>().enabled = false;

            //    Robo2.GetComponent<RoboController>().enabled = true;
            //}
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1") && Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {
            AudioManagerRt.instance.PlaySfx(3);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
            sr.sprite = off;
            isPressed = false;

           // PoleRobo1.sprite = PoleOff;
        }
    }




}
