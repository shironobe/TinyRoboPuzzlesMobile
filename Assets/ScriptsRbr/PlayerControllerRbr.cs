using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerRbr : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
    public static PlayerControllerRbr instance;

    public bool canMove;




    //public GameObject mPlayer;
    //private Invoker mInvoker;

   
    private void Awake()
    {
        instance = this;
    }

    //public interface ICommand
    //{
    //    void Execute();
    //    void ExecuteUndo();
    //}
    //public class CommandMove : ICommand
    //{
    //    // Start is called before the first frame update
    //    public CommandMove( GameObject obj, Vector3 direction)
    //    {
          
    //        mGameObject = obj;
    //        mDirection = direction;
    //    }

    //    public void Execute()
    //    {

    //        PlayerController.instance.Destination = mGameObject.transform.position + mDirection;

           
    //       // mGameObject.transform.position = Vector3.MoveTowards(mGameObject.transform.position, mGameObject.transform.position + mDirection, 9* Time.deltaTime);
    //    }

    //    public void ExecuteUndo()
    //    {
    //        // mGameObject.transform.position -= mDirection;
    //        mGameObject.transform.position = mGameObject.transform.position - mDirection;
    //    }

    //    GameObject mGameObject;
    //    Vector3 mDirection;

        
       
    //}

    //public class Invoker
    //{
    //    public Invoker()
    //    {
    //        mCommands = new Stack<ICommand>();
    //    }

    //    public void Execute(ICommand command)
    //    {
    //        if (command != null)
    //        {
    //            mCommands.Push(command);
    //            mCommands.Peek().Execute();
    //        }
    //    }

    //    public void Undo()
    //    {
    //        if (mCommands.Count > 0)
    //        {
    //            mCommands.Peek().ExecuteUndo();
    //            mCommands.Pop();
    //        }
    //    }

    //    Stack<ICommand> mCommands;
    //}

    void Start()
    {
        Destination = transform.position;

        canMove = true;
        speed = 14f;

      //  mInvoker = new Invoker();

      //  mPlayer = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    
    {

        // Debug.Log(Vector3.Distance(transform.position, Destination));
        // Debug.Log(Mathf.Epsilon);

        //  if (!Manager.instance.Mobile)
        //  {
        if (Input.GetKeyDown(KeyCode.U) && Vector3.Distance(transform.position, Destination) < Mathf.Epsilon)
        {
           // mInvoker.Undo();
         //   Destination = mPlayer.transform.position;
        }
        else
        {

         //   transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);

           // Destination = mPlayer.transform.position;
        }

        if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
        {


            //Debug.Log(Input.GetAxisRaw("Horizontal"));
            //Debug.Log(Input.GetAxisRaw("Vertical"));
            //Debug.Log(CheckDirection(Vector3.right));
       
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (CheckDirection(Vector3.left))
                   {
                    //    ICommand move = new CommandMove(mPlayer, Vector3.left);
                    //    mInvoker.Execute(move);
                    //    Destination = mPlayer.transform.position;

                         Destination = transform.position + Vector3.left;
                        // AudioManager.instance.PlaySfx(6);
                    }
                }
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {

                    if (CheckDirection(Vector3.up))
                    {

                        //ICommand move = new CommandMove(mPlayer, Vector3.up);
                        //mInvoker.Execute(move);
                        //Destination = mPlayer.transform.position;
                       Destination = transform.position + Vector3.up;
                        //  AudioManager.instance.PlaySfx(6);
                    }
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (CheckDirection(Vector3.down))
                    {
                        //ICommand move = new CommandMove(mPlayer, Vector3.down);
                        //mInvoker.Execute(move);
                        //Destination = mPlayer.transform.position;
                        Destination = transform.position + Vector3.down;
                        //  AudioManager.instance.PlaySfx(6);
                    }
                }
            }
            //if (Input.GetKey(KeyCode.W))
            //{
            //    if (CheckDirection(Vector3.up))
            //    {
            //        Destination = transform.position + Vector3.up;
            //    }


            //}
            //else if (Input.GetKey(KeyCode.D))
            //{

            //    if (CheckDirection(Vector3.right))
            //    {
            //        Destination = transform.position + Vector3.right;
            //        Debug.Log("Right pushed");
            //    }
            //}
            //else if (Input.GetKey(KeyCode.S))
            //{
            //    if (CheckDirection(Vector3.down))
            //    {
            //        Destination = transform.position + Vector3.down;

            //    }
            //}
            //else if (Input.GetKey(KeyCode.A))
            //{
            //    if (CheckDirection(Vector3.left))
            //    {
            //        Destination = transform.position + Vector3.left;
            //    }
            //}
        }
       
        else
        {
           

            transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);

          
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            //  replaylevel();
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        }


    }

    public void MoveUp()
    {

        if (!ManagerRbr.instance.isRobo2Active)
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
            ROBO2Rbr.instance.UpmagnetUse();
        }
    }

    public void MoveDown()
    {

        if (!ManagerRbr.instance.isRobo2Active)
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
            ROBO2Rbr.instance.DownmagnetUse();
        }
    }

    public void MoveRight()
    {

        if (!ManagerRbr.instance.isRobo2Active)
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
            ROBO2Rbr.instance.RightmagnetUse();
        }
    }

    public void MoveLeft()
    {

        if (!ManagerRbr.instance.isRobo2Active)
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
            ROBO2Rbr.instance.LeftmagnetUse();
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

       // ICommand move = new CommandMove(mPlayer, direction);
       // mInvoker.Execute(move);
       //Destination = mPlayer.transform.position;
       Destination = transform.position + direction;
    }
    private bool CheckDirection(Vector3 direction) { 
    //{
    //    Ray2D Ray = new Ray2D(transform.position, direction);

    //    RaycastHit2D hit;
    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
       
         //   Debug.DrawRay(transform.position, direction);

       // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
      //  Debug.DrawRay(hit1pos.transform.position, direction);

        if (hit)
        {
           string tag = hit.transform.tag;
          
            if (hit.collider.gameObject.CompareTag("Pushable") || hit.collider.gameObject.CompareTag("Robo2") || hit.collider.gameObject.CompareTag("PushableWoodBlock"))
            {
                PushableBlockRbr pushableBlock = hit.collider.GetComponent<PushableBlockRbr>();

               
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
            //  AudioManager.instance.PlaySfx(6);
        }
    }
    public void Left()
    {
        if (CheckDirection(Vector3.left))
        {
            Destination = transform.position + Vector3.left;
            // AudioManager.instance.PlaySfx(6);
        }
    }


    public void Up()
    {
        if (CheckDirection(Vector3.up))
        {
            Destination = transform.position + Vector3.up;
            //  AudioManager.instance.PlaySfx(6);
        }
    }

    public void Down()
    {

        if (CheckDirection(Vector3.down))
        {
            Destination = transform.position + Vector3.down;
            //  AudioManager.instance.PlaySfx(6);
        }
    }
}
