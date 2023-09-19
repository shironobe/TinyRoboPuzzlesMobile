using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class RoboTwin2Merge : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
 

    public bool canMove;
    //#if UNITY_WEBGL
 
    //#endif

    Animator SceneTransition;

    public GameObject[] Blocks;

    bool ShouldCheck;
  
    //  public List<Vector3> lastPos = new List<Vector3>();

    // public int moveplayerNo = 0;
    public SpriteRenderer sr;

    public bool isBomb;

   


    void Start()
    {
        Destination = transform.position;
        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
        box2d.isTrigger = true;
        canMove = true;
        // Bats = GameObject.FindGameObjectsWithTag("Bat");
        // SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();

        Blocks = GameObject.FindGameObjectsWithTag("Pushable");
        //  stopsign = GameObject.FindGameObjectWithTag("Stop");

        sr = GetComponent<SpriteRenderer>();
        //  noOfMoves = GameObject.FindGameObjectWithTag("EnergyLeft").GetComponent<Text>();
        //  noOfMoves.text = Moves.ToString();
    }

    // Update is called once per frame


    void Update()

    {



        if (Vector3.Distance(transform.position,Destination) < Mathf.Epsilon)
        {


            transform.position = Destination;

          

            PlayerControllerMerge.instance.canMove = true;

         
        }
        else
        {

           
                  
                    transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);
              
          

        }

        foreach (GameObject block in Blocks)
        {
            if (!block.GetComponent<PushableBlockMerge>().isPushed)
            {

                ShouldCheck = true;

            }
            else
            {
                ShouldCheck = false;
            }
        }
                // Debug.Log(Vector3.Distance(transform.position, Destination));
                // Debug.Log(Mathf.Epsilon);

                //  if (!Manager.instance.Mobile)
                ////  {
                //if (!isDead)
                //{

                //    if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
                //    {

                //        //Debug.Log(Input.GetAxisRaw("Horizontal"));
                //        //Debug.Log(Input.GetAxisRaw("Vertical"));
                //        //Debug.Log(CheckDirection(Vector3.right));

                //        if (Input.GetAxisRaw("Horizontal") > 0)
                //        {
                //            // sr.flipX = false;
                //            isUndoing = false;

                //            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                //            {
                //                if (CheckDirection(Vector3.left))
                //                {

                //                    foreach (GameObject Bat in Bats)
                //                    {
                //                        // Bat.GetComponent<BatMove>().batMove();
                //                    }



                //                    Destination = transform.position + Vector3.left;

                //                    //  Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                //                    //  CommandInvoker.AddCommand(command);
                //                    //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                //                    //  AudioManager.instance.PlaySfx(1);


                //                }
                //            }
                //        }
                //        else if (Input.GetAxisRaw("Horizontal") < 0)
                //        {
                //            //  sr.flipX = true;
                //            isUndoing = false;
                //            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                //            {
                //                if (CheckDirection(Vector3.right))
                //                {
                //                    foreach (GameObject Bat in Bats)
                //                    {
                //                        //  Bat.GetComponent<BatMove>().batMove();
                //                    }

                //                    Destination = transform.position + Vector3.right;

                //                    // Destination = mPlayer.transform.position;

                //                    //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                //                    //CommandInvoker.AddCommand(command);
                //                    //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                //                    //  AudioManager.instance.PlaySfx(1);


                //                }
                //            }
                //        }
                //        else if (Input.GetAxisRaw("Vertical") > 0)
                //        {
                //            isUndoing = false;
                //            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                //            {

                //                if (CheckDirection(Vector3.down))
                //                {
                //                    foreach (GameObject Bat in Bats)
                //                    {
                //                        // Bat.GetComponent<BatMove>().batMove();
                //                    }

                //                    Destination = transform.position + Vector3.down;

                //                    //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                //                    //CommandInvoker.AddCommand(command);

                //                    //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                //                    //  AudioManager.instance.PlaySfx(1);


                //                }
                //            }
                //        }
                //        else if (Input.GetAxisRaw("Vertical") < 0)
                //        {
                //            isUndoing = false;
                //            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                //            {
                //                if (CheckDirection(Vector3.up))
                //                {


                //                    Destination = transform.position + Vector3.up;

                //                    //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                //                    //CommandInvoker.AddCommand(command);

                //                    // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                //                    // AudioManager.instance.PlaySfx(1);


                //                }
                //            }
                //        }

                //        //}

                //    }
                //    else
                //    {


                //        transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);


                //    }

                //}
                //}

                if (Input.GetKeyDown(KeyCode.R))
        {
            //  replaylevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
   

    //private bool CheckDirection(Vector3 direction)
    //{  

    //    // Debug.DrawRay(transform.position, direction);

    //   .// RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
    //    if (Physics.Raycast(transform.position, direction, out RaycastHit hit,   detectionRadius, BlockMask))
    //    {
    //        Debug.DrawRay(transform.position, direction);

    //        if (hit.collider.CompareTag("Pushable"))
    //        {

    //            PushableBlock pushableBlock = hit.collider.GetComponent<PushableBlock>();
    //            Debug.Log("BlockFound");

    //            if (!pushableBlock)
    //            {
    //                return false;
    //            }
    //              pushableBlock.Push(direction, speed);


    //        }
    //        return false;
    //    }
    //    return true;
    //}


    public void MovePlayer(Vector3 direction)
    {



        // Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        //  CommandInvoker.AddCommand(command);

          if (CheckDirection(direction))
            {
           

                    Destination = transform.position + direction;
                
           
            }
        

    }


   
   

    public void UnMovePlayer(Vector3 direction)
    {

        //foreach (GameObject Bat in Bats)
        //{
        //    Bat.GetComponent<BatMove>().batMove();
        //}
        //  AudioManager.instance.PlaySfx(1);

        //Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        // CommandInvoker.AddCommand(command);
        if (ShouldCheck)
        {
            Destination = transform.position - direction;
        }


    }
    private bool CheckDirection(Vector3 direction)
    {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
       

        Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
        //  Debug.DrawRay(hit1pos.transform.position, direction);

        if (hit.collider != null )
        {
            if (hit.collider.CompareTag("Robo"))
            {
               RoboTwin2Merge robotwin2 = hit.collider.GetComponent<RoboTwin2Merge>();

              //  robotwin2.MovePlayer(direction);

                if (robotwin2.CheckDirection(direction) )
                {
                    return true;
                }
            }
            
            return false;


           
        }


    
            return true;
        
      
    }

    public void Right()
    {
        if (CheckDirection(Vector3.right))
        {
            Destination = transform.position + Vector3.right;
            // AudioManager.instance.PlaySfx(1);
        }
    }
    public void Left()
    {
        if (CheckDirection(Vector3.left))
        {
            Destination = transform.position + Vector3.left;
            //AudioManager.instance.PlaySfx(1);
        }
    }


    public void Up()
    {
        if (CheckDirection(Vector3.up))
        {
            Destination = transform.position + Vector3.up;
            //   AudioManager.instance.PlaySfx(1);
        }
    }

    public void Down()
    {

        if (CheckDirection(Vector3.down))
        {
            Destination = transform.position + Vector3.down;
            //  AudioManager.instance.PlaySfx(1);
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    inContact = true;
    //    stopsign.SetActive(true);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    inContact = false;
    //}


    

    IEnumerator NextLevel()
    {

        SceneTransition.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
