using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class PlayerControllerRes : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
    public static PlayerControllerRes instance;

    public bool canMove;
   
   

    Animator SceneTransition;

    public GameObject mPlayer;
   

  

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

    public GameObject RedBotClone;

    public LayerMask inContact;
    public Transform Contact;

    public int MoveNo;

    public bool onLand;
    public LayerMask onLandCheck;

    public bool isBlockDecreasing;

    public Sprite onLandplayer, InWaterplayer;
  

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
        // Robos = GameObject.FindGameObjectsWithTag("Robo");
        //  BombBot = GameObject.FindGameObjectsWithTag("BombBot");
        // SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
     

        //  stopsign = GameObject.FindGameObjectWithTag("Stop");
        mPlayer = this.gameObject;
        sr = GetComponent<SpriteRenderer>();
        Blocks = GameObject.FindGameObjectsWithTag("Pushable");
        //  noOfMoves = GameObject.FindGameObjectWithTag("EnergyLeft").GetComponent<Text>();
        //  noOfMoves.text = Moves.ToString();

     //   Instantiate(RedBotClone, transform.position, Quaternion.identity); 
    }

    // Update is called once per frame

   
    void Update()

    {

        // Debug.Log(Vector3.Distance(transform.position, Destination));
        // Debug.Log(Mathf.Epsilon);

        //  if (!Manager.instance.Mobile)
        //  {
        isDead = Physics2D.OverlapCircle(Contact.position, 0.2f, inContact);
        onLand = Physics2D.OverlapCircle(Contact.position, 0.2f, onLandCheck);



        if (onLand)
        {
            sr.sprite = onLandplayer;
        }
        else
        {
            sr.sprite = InWaterplayer;
        }

        if (!isDead )
        {
           
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
            {

                //Debug.Log(Input.GetAxisRaw("Horizontal"));
                //Debug.Log(Input.GetAxisRaw("Vertical"));
                //Debug.Log(CheckDirection(Vector3.right));

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                   // sr.flipX = false;
                   

                   if (Input.GetKeyDown(KeyCode.D) )
                    {
                        if (CheckDirection(Vector3.right))
                        {


                           

                            Destination = transform.position + Vector3.right;
                           
                            //  Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                            //  CommandInvoker.AddCommand(command);
                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                            //  AudioManager.instance.PlaySfx(5);
                            //  Instantiate(RedBotClone, transform.position, Quaternion.identity);

                        }
                    }
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                  //  sr.flipX = true;
                   
                    if (Input.GetKeyDown(KeyCode.A) )
                    {
                        if (CheckDirection(Vector3.left))
                        {
                            

                            Destination = transform.position + Vector3.left;

                          

                            // Destination = mPlayer.transform.position;

                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                            //CommandInvoker.AddCommand(command);
                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                            //   AudioManager.instance.PlaySfx(5);
                            //   Instantiate(RedBotClone, transform.position, Quaternion.identity);

                        }
                    }
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                   
                    if (Input.GetKeyDown(KeyCode.W) )
                    {

                        if (CheckDirection(Vector3.up))
                        {
                           

                            Destination = transform.position + Vector3.up;

                           
                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                            //CommandInvoker.AddCommand(command);

                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                            //  AudioManager.instance.PlaySfx(5);
                            //   Instantiate(RedBotClone, transform.position, Quaternion.identity);

                        }
                    }
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                  
                    if (Input.GetKeyDown(KeyCode.S) )
                   {

                        if (CheckDirection(Vector3.down))
                        {
                           
                            Destination = transform.position + Vector3.down;
                           

                          //  Instantiate(RedBotClone, transform.position, Quaternion.identity);
                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                            //CommandInvoker.AddCommand(command);

                            // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                            // AudioManager.instance.PlaySfx(5);


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
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

      
}


    public void MoveUp()
    {

        if (ManagerRes.instance.isPlayerActive)
        {
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
            {
                if (CheckDirection(Vector3.up))
                {


                    //ICommand move = new CommandMove(mPlayer, Vector3.right);
                    //mInvoker.Execute(move);
                    //Destination = mPlayer.transform.position;

                    Destination = transform.position + Vector3.up;

                    //  AudioManager.instance.PlaySfx(6);
                }
            }
        }
        else
        {
            GreenBotRes.instance.Up();
        }
    }

    public void MoveDown()
    {

        if (ManagerRes.instance.isPlayerActive)
        {
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
            {
                if (CheckDirection(Vector3.down))
                {


                    //ICommand move = new CommandMove(mPlayer, Vector3.right);
                    //mInvoker.Execute(move);
                    //Destination = mPlayer.transform.position;

                    Destination = transform.position + Vector3.down;
                    //  AudioManager.instance.PlaySfx(6);
                }
            }
        }
        else
        {
            GreenBotRes.instance.Down();
        }
    }

    public void MoveRight()
    {

        if (ManagerRes.instance.isPlayerActive)
        {
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
            {
                if (CheckDirection(Vector3.right))
                {


                    //ICommand move = new CommandMove(mPlayer, Vector3.right);
                    //mInvoker.Execute(move);
                    //Destination = mPlayer.transform.position;

                    Destination = transform.position + Vector3.right;
                    //  AudioManager.instance.PlaySfx(6);
                }
            }
        }
        else
        {
            GreenBotRes.instance.Right();
        }
    }

    public void MoveLeft()
    {

        if (ManagerRes.instance.isPlayerActive)
        {
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
            {
                if (CheckDirection(Vector3.left))
                {


                    //ICommand move = new CommandMove(mPlayer, Vector3.right);
                    //mInvoker.Execute(move);
                    //Destination = mPlayer.transform.position;

                    Destination = transform.position + Vector3.left;
                    //  AudioManager.instance.PlaySfx(6);
                }
            }
        }
        else
        {
            GreenBotRes.instance.Left();
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
        AudioManagerRes.instance.PlaySfx(5);
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

      //  Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
        //  Debug.DrawRay(hit1pos.transform.position, direction);


        


        if (hit)
        {
           string tag = hit.transform.tag;

            if (hit.collider.gameObject.CompareTag("Rocks"))
            {

                return false;
            }

            if (hit.collider.gameObject.CompareTag("FinishSign"))
            {
               
                return false;
            }


            if (hit.collider.gameObject.CompareTag("GreenBot"))
            {
              
                return false;
            }
           

                if (hit.collider.gameObject.CompareTag("RedBlock") && !hit.collider.gameObject.GetComponent<WoodBlockRes>().isPlayerContact)
            {
                if (!hit.collider.gameObject.GetComponent<WoodBlockRes>().isPlayerContact)
                {
                    AudioManagerRes.instance.PlaySfx(2);
                    Destroy(hit.collider.gameObject);
                    MoveNo++;
                    isBlockDecreasing = true;


                    return true;
                }
            }else if (hit.collider.gameObject.CompareTag("Land")) {

                if (!isBlockDecreasing && !onLand && MoveNo > 0)
                {
                    AudioManagerRes.instance.PlaySfx(3);
                    Instantiate(RedBotClone, transform.position, Quaternion.identity);
                    MoveNo--;
                    isBlockDecreasing = true;
                    return true;
                }
                
               // return true;
           }

            

            //if (hit.collider.gameObject.CompareTag("GroundBlock"))
            //{


            //    return false;
            //}

            if (hit.collider.gameObject.CompareTag("Pushable") )
            {
                PushableBlockRes pushableBlock = hit.collider.GetComponent<PushableBlockRes>();

               
                if (!pushableBlock)
                    return false;

                
                pushableBlock.Push(direction, speed);
               // Destination = transform.position + direction;


            }
          
            return true;
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
        if (!hit && MoveNo > 0 && !onLand )
        {
            AudioManagerRes.instance.PlaySfx(3);
            Instantiate(RedBotClone, transform.position, Quaternion.identity);
            MoveNo--;
            isBlockDecreasing = false;
            return true;
        }
        if (MoveNo > 0 && !onLand)
        {
          
            return true;
        }
        if( onLand)
        {
            return true;
        }
       
        return false;
       
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



    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        if (other.CompareTag("GreenBot"))
        {
            isDead = false;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenBot"))
        {
            isDead = true;
        }

        //}
        //if (other.CompareTag("Hole")){
        //    other.gameObject.SetActive(true);
        //}
        //  if(Robono <= 0)
        //    {
        //       // startlevel();
        //        StartCoroutine(NextLevel());
        //        if (PlayerPrefs.GetInt("LevelUnlock") < SceneManager.GetActiveScene().buildIndex + 1)
        //        {
        //            PlayerPrefs.SetInt("LevelUnlock", SceneManager.GetActiveScene().buildIndex + 1);
        //        }
        //     //   Debug.Log("Finished");
        //    }


        //}
    }
        
    
    
    
 
    
  



    IEnumerator NextLevel()
    {

       // SceneTransition.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
