using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class RoboControllerRt : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
    public static RoboControllerRt instance;

    public bool canMove;
//#if UNITY_WEBGL
   
    Animator SceneTransition;

   
   

    public bool inContactWithPlayer;



    public bool isMoving;

    bool blockPushed;
    //  public List<Vector3> lastPos = new List<Vector3>();

    // public int moveplayerNo = 0;
    public SpriteRenderer sr;



    bool isDead;

  //  public Transform N, S;
    public bool PlayerMoved;
    private void Awake()
    {
        instance = this;
    }

   
    void Start()
    {
        Destination = transform.position;
        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
       // box2d.isTrigger = true;
        canMove = true;
       
      //  SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();


        //  stopsign = GameObject.FindGameObjectWithTag("Stop");
      
        sr = GetComponent<SpriteRenderer>();
        //  noOfMoves = GameObject.FindGameObjectWithTag("EnergyLeft").GetComponent<Text>();
        //  noOfMoves.text = Moves.ToString();


        // Switch to 640 x 480 full-screen
        //    Screen.SetResolution(640, 480, true);
        
    }

    // Update is called once per frame

   
    void Update()

    {
       // Screen.SetResolution(320, 180, true);
        // Debug.Log(Vector3.Distance(transform.position, Destination));
        // Debug.Log(Mathf.Epsilon);

        //  if (!Manager.instance.Mobile)
        //  {
        if (!isDead)
        {
            isMoving = false;
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
            {

                //Debug.Log(Input.GetAxisRaw("Horizontal"));
                //Debug.Log(Input.GetAxisRaw("Vertical"));
                //Debug.Log(CheckDirection(Vector3.right));

                //if (Input.GetAxisRaw("Horizontal") > 0)
                //{
                  

                   if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                    {
                        if (CheckDirection(Vector3.right))
                        {


                        //   sr.flipX = false;

                        PlayerMoved = true;
                          // Destination = transform.position + Vector3.right ;

                            Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                        CommandInvoker.instance.AddCommand(command);
                        //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                        AudioManagerRt.instance.PlaySfx(9);


                    }
                    //}
                   }
               
                   
                   else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                    {
                      if (CheckDirection(Vector3.left))
                        {
                        PlayerMoved = true;
                       // Destination = transform.position + Vector3.left ; 
                          //   sr.flipX = true;
                        // Destination = mPlayer.transform.position;

                        Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                        CommandInvoker.instance.AddCommand(command);
                        //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                        // AudioManager.instance.PlaySfx(1);
                        AudioManagerRt.instance.PlaySfx(9);


                    }
                   }
                
               
                  else if ( Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                   {

                        if (CheckDirection(Vector3.up))
                        {
                        PlayerMoved = true;

                       // Destination = transform.position + Vector3.up ; 

                        Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                        CommandInvoker.instance.AddCommand(command);

                        //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                        // AudioManager.instance.PlaySfx(1);
                        AudioManagerRt.instance.PlaySfx(9);

                    }
                    //}
                  }
               
                   
                 else  if ( Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                  {
                        if (CheckDirection(Vector3.down))
                        {
                        PlayerMoved = true;
                      //  Destination = transform.position + Vector3.down  ;

                        Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);


                        CommandInvoker.instance.AddCommand(command);

                        // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                        //  AudioManager.instance.PlaySfx(1);
                        AudioManagerRt.instance.PlaySfx(9);


                    }
                   // }
                 }

                //}

            }
            else
            {

                isMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);


            }

        } 
        //}
        

      
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

    public void MoveUp()
    {

       if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.up))
            {
                PlayerMoved = true;

                // Destination = transform.position + Vector3.up ; 

                Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                CommandInvoker.instance.AddCommand(command);

                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                // AudioManager.instance.PlaySfx(1);
                AudioManagerRt.instance.PlaySfx(9);

            }
        }
        
    }

    public void MoveDown()
    {

        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.down))
            {
                PlayerMoved = true;

                // Destination = transform.position + Vector3.up ; 

                Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                CommandInvoker.instance.AddCommand(command);

                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                // AudioManager.instance.PlaySfx(1);
                AudioManagerRt.instance.PlaySfx(9);

            }
        }
    }

    public void MoveRight()
    {
        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.right))
            {
                PlayerMoved = true;

                // Destination = transform.position + Vector3.up ; 

                Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                CommandInvoker.instance.AddCommand(command);

                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                // AudioManager.instance.PlaySfx(1);
                AudioManagerRt.instance.PlaySfx(9);

            }
        }
    }

    public void MoveLeft()
    {

        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.left))
            {
                PlayerMoved = true;

                // Destination = transform.position + Vector3.up ; 

                Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                CommandInvoker.instance.AddCommand(command);

                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                // AudioManager.instance.PlaySfx(1);
                AudioManagerRt.instance.PlaySfx(9);

            }
        }
    }
    public void MovePlayer(Vector3 direction)
    {

       


        // Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        //  CommandInvoker.AddCommand(command);

        Destination = transform.position + direction;
       // AudioManager.instance.PlaySfx(1);


    }

    public void UnMovePlayer(Vector3 direction)
    {




        // Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        //  CommandInvoker.AddCommand(command);

        Destination = transform.position - direction;
        // AudioManager.instance.PlaySfx(1);


    }




    private bool CheckDirection(Vector3 direction) { 
  //  
  //  RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);

       
        Debug.DrawRay(transform.position, direction);

       // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
      //  Debug.DrawRay(hit1pos.transform.position, direction);

        if ( hit)
        {
            // string tag = hit.transform.tag;



            //if (hit.collider.gameObject.CompareTag("Land"))
            //{



            //    return true;

            //}






            //   if (!PlayerController.instance.isDead)
            //  {

            // }
            if (hit.collider.gameObject.CompareTag("Pushable") )
            {
                PushableBlockRt pushableBlock = hit.collider.GetComponent<PushableBlockRt>();
            


                if (!pushableBlock)
                    return false;


                pushableBlock.Push(direction, speed);

                // Destination = transform.position + direction;

                return false;
            }

            // Debug.Log("Here");

            return false;
        }
        //if (hit1)
        //{
        //    string tag = hit1.transform.tag;

        //    if (hit1.collider.gameObject.CompareTag("Pushable"))
        //    {
        //        PushableBlock pushableBlock = hit1.collider.GetComponent<PushableBlock>();


        //        if (!pushableBlock)
        //            return false;


        //        pushableBlock.Push(direction, speed);



        //    }
        //    return false;
        //}
     
        return true;
       
    }

    public void Right()
    {
        if (CheckDirection(Vector3.right))
        {
            Destination = transform.position + Vector3.right;
            AudioManagerRt.instance.PlaySfx(1);
        }
    }
    public void Left()
    {
        if (CheckDirection(Vector3.left))
        {
            Destination = transform.position + Vector3.left;
            AudioManagerRt.instance.PlaySfx(1);
        }
    }


    public void Up()
    {
        if (CheckDirection(Vector3.up))
        {
            Destination = transform.position + Vector3.up;
            AudioManagerRt.instance.PlaySfx(1);
        }
    }

    public void Down()
    {

        if (CheckDirection(Vector3.down))
        {
            Destination = transform.position + Vector3.down;
            AudioManagerRt.instance.PlaySfx(1);
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Finish"))
        //{
        //  //  Debug.Log("Level FInished");
        //   // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //   //  startlevel();

        //    StartCoroutine(NextLevel());
        //    if (PlayerPrefs.GetInt("LevelUnlock") < SceneManager.GetActiveScene().buildIndex+1)
        //    {
        //        PlayerPrefs.SetInt("LevelUnlock", SceneManager.GetActiveScene().buildIndex + 1);
        //    }
        //}

        
    }
    

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
