using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class PlayerControllerMerge : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
    public static PlayerControllerMerge instance;

    public bool canMove;
    //#if UNITY_WEBGL
   

    Animator SceneTransition;

    public GameObject mPlayer;
   

    public bool inContact;

    GameObject stopsign;

    public bool isUndoing;
    //  public List<Vector3> lastPos = new List<Vector3>();

    // public int moveplayerNo = 0;
    public SpriteRenderer sr;

    public int Moves;

    public Text noOfMoves;

    

    public GameObject[] Robos;

    public GameObject[] BombBot;

    public GameObject PlayerDeathEffect;

    public int[] twinrobos;
    public bool isStrong;

    public GameObject[] Blocks;
   public  bool isDead;

    bool allActive;

    public int Robono;
    private void Awake()
    {
        instance = this;
    }

   
    void Start()
    {
        Destination = transform.position;
        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
        box2d.isTrigger = true;
        canMove = true;
        Robos = GameObject.FindGameObjectsWithTag("Robo");
        BombBot = GameObject.FindGameObjectsWithTag("BombBot");
       // SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();


        //  stopsign = GameObject.FindGameObjectWithTag("Stop");
        mPlayer = this.gameObject;
        sr = GetComponent<SpriteRenderer>();
        Blocks = GameObject.FindGameObjectsWithTag("Pushable");
      //  noOfMoves = GameObject.FindGameObjectWithTag("EnergyLeft").GetComponent<Text>();
      //  noOfMoves.text = Moves.ToString();
    }

    // Update is called once per frame

   
    void Update()

    {

        // Debug.Log(Vector3.Distance(transform.position, Destination));
        // Debug.Log(Mathf.Epsilon);

        //  if (!Manager.instance.Mobile)
        //  {
        Robos = GameObject.FindGameObjectsWithTag("Robo");
        BombBot = GameObject.FindGameObjectsWithTag("BombBot");
        if (!isDead)
        {
           
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
            {

                //Debug.Log(Input.GetAxisRaw("Horizontal"));
                //Debug.Log(Input.GetAxisRaw("Vertical"));
                //Debug.Log(CheckDirection(Vector3.right));

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                   // sr.flipX = false;
                    isUndoing = false;

                   if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (CheckDirection(Vector3.right))
                        {


                            foreach (GameObject Robo in Robos)
                               {
                                Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.left);
                               }
                            foreach (GameObject bombbot in BombBot)
                            {
                                bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.left);
                            }

                            Destination = transform.position + Vector3.right;

                            //  Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                            //  CommandInvoker.AddCommand(command);
                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                            AudioManagerMerge.instance.PlaySfx(5);


                        }
                    }
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                  //  sr.flipX = true;
                    isUndoing = false;
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (CheckDirection(Vector3.left))
                        {
                            

                            Destination = transform.position + Vector3.left;

                            foreach (GameObject Robo in Robos)
                            {
                                Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.right);
                            }

                            foreach (GameObject bombbot in BombBot)
                            {
                               bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.right);
                            }

                            // Destination = mPlayer.transform.position;

                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                            //CommandInvoker.AddCommand(command);
                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                            AudioManagerMerge.instance.PlaySfx(5);


                        }
                    }
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    isUndoing = false;
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {

                        if (CheckDirection(Vector3.up))
                        {
                           

                            Destination = transform.position + Vector3.up;

                            foreach (GameObject Robo in Robos)
                            {
                                Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.down);
                            }

                            foreach (GameObject bombbot in BombBot)
                            {
                                bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.down);
                            }
                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                            //CommandInvoker.AddCommand(command);

                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                            AudioManagerMerge.instance.PlaySfx(5);


                        }
                    }
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    isUndoing = false;
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                   {
                        if (CheckDirection(Vector3.down))
                        {
                            foreach (GameObject Robo in Robos)
                            {
                                Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.up);
                            }
                            foreach (GameObject bombbot in BombBot)
                            {
                                bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.up);
                            }
                            Destination = transform.position + Vector3.down;



                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                            //CommandInvoker.AddCommand(command);

                            // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                            AudioManagerMerge.instance.PlaySfx(5);


                        }
                    }
                }

                //}

            }
            else
            {


                transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);


            }

        } 
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

    public void MoveUp()
    {
        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.up))
            {


                Destination = transform.position + Vector3.up;

                foreach (GameObject Robo in Robos)
                {
                    Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.down);
                }

                foreach (GameObject bombbot in BombBot)
                {
                    bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.down);
                }
                //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                //CommandInvoker.AddCommand(command);

                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                AudioManagerMerge.instance.PlaySfx(5);


            }
        }
    }

    public void MoveDown()
    {

        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.down))
            {
                foreach (GameObject Robo in Robos)
                {
                    Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.up);
                }
                foreach (GameObject bombbot in BombBot)
                {
                    bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.up);
                }
                Destination = transform.position + Vector3.down;



                //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                //CommandInvoker.AddCommand(command);

                // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                AudioManagerMerge.instance.PlaySfx(5);


            }
        }
    }

    public void MoveRight()
    {

         if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
            {
            if (CheckDirection(Vector3.right))
            {


                foreach (GameObject Robo in Robos)
                {
                    Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.left);
                }
                foreach (GameObject bombbot in BombBot)
                {
                    bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.left);
                }

                Destination = transform.position + Vector3.right;

                //  Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                //  CommandInvoker.AddCommand(command);
                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                AudioManagerMerge.instance.PlaySfx(5);
            }
        }
      
    }

    public void MoveLeft()
    {
        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
            if (CheckDirection(Vector3.left))
            {


                Destination = transform.position + Vector3.left;

                foreach (GameObject Robo in Robos)
                {
                    Robo.GetComponent<RoboTwin2Merge>().MovePlayer(Vector3.right);
                }

                foreach (GameObject bombbot in BombBot)
                {
                    bombbot.GetComponent<BombBotMerge>().MovePlayer(Vector3.right);
                }

                // Destination = mPlayer.transform.position;

                //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                //CommandInvoker.AddCommand(command);
                //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                AudioManagerMerge.instance.PlaySfx(5);


            }
        }
    }

    public void MovePlayer(Vector3 direction)
    {




        // Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        //  CommandInvoker.AddCommand(command);
        AudioManagerMerge.instance.PlaySfx(5);
        Destination = transform.position + direction;

        // foreach(GameObject block in Blocks)
        // {
        //  if(!block.GetComponent<PushableBlock>().isPushed)

        // }
        StartCoroutine(MoveRobo(direction));
       
    }

    IEnumerator MoveRobo(Vector3 direction)
    {
        yield return new WaitForSeconds(0.13f);

        foreach (GameObject Robo in Robos)
        {
            Robo.GetComponent<RoboTwin2Merge>().MovePlayer(-direction);
        }

        foreach (GameObject bombbot in BombBot)
        {
            bombbot.GetComponent<BombBotMerge>().MovePlayer(-direction);
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
         Destination = transform.position - direction;


    }
    private bool CheckDirection(Vector3 direction) { 
    
    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
       
        //Debug.DrawRay(transform.position, direction);

       // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
      //  Debug.DrawRay(hit1pos.transform.position, direction);

        if (hit)
        {
           string tag = hit.transform.tag;
          
            if (hit.collider.gameObject.CompareTag("Pushable") )
            {
                PushableBlockMerge pushableBlock = hit.collider.GetComponent<PushableBlockMerge>();

               
                if (!pushableBlock)
                    return false;

                
                pushableBlock.Push(direction, speed);
               // Destination = transform.position + direction;


            }
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

   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Robo"))
        {
            // other.gameObject.GetComponent<RoboTwin2>().isDead = true;
            AudioManagerMerge.instance.PlaySfx(1);
            Robono--;
            other.gameObject.SetActive(false);
          //  Destroy(other.gameObject, 0f);



          if(Robono <= 0)
            {
               // startlevel();
                StartCoroutine(NextLevel());
                if (PlayerPrefs.GetInt("LevelUnlockMerge") < SceneManager.GetActiveScene().buildIndex + 1)
                {
                    PlayerPrefs.SetInt("LevelUnlockMerge", SceneManager.GetActiveScene().buildIndex + 1-23);
                }
             //   Debug.Log("Finished");
            }

           
        }

    }

  



    IEnumerator NextLevel()
    {

       // SceneTransition.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);

        if (SceneManager.GetActiveScene().buildIndex == 45)
        {
            SceneManager.LoadScene(94);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }

    public void Restart()
    {
        Invoke("RestartLevel", 0.2f);
    }
   public void RestartLevel()
    {
       // replaylevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
