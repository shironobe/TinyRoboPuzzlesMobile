using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlockRt : MonoBehaviour
{

    public static PushableBlockRt instance;
    public bool isPushed;
    public bool isHooked;

    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;

      public Vector3 destination;
    public float _speed ;
    float speedMultiplyer = 1.5f;

    public bool shouldHook;

    public bool isDestroyable;

   

    

   
  

    

   
    private void Awake()
    {
        instance = this;
       
    }

  
    
    void Start()
    {
        destination = transform.position;
        
        shouldHook = false;
      

       
       
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)







        if (Vector3.Distance(transform.position, destination) < Mathf.Epsilon )
            {

          
            transform.position = destination;

              isPushed = false;

              isHooked = false;

          
            RoboControllerRt.instance.canMove = true;
          

        }
            else
            {

          

      
        transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
           

        }
        

        // anim.SetBool("isMoving", isPushed);
    }
    public void Push(Vector3 direction, float speed)
    {
       
        if (!isPushed)
        {
            if (CheckDirection(direction))
            {
                if (Vector3.Distance(RoboControllerRt.instance.transform.position, RoboControllerRt.instance.Destination) < Mathf.Epsilon)
                {
                    // Debug.Log("ImPushed");

                    AudioManagerRt.instance.PlaySfx(9);
                    Icommand command = new PushRockCommand(this.gameObject, direction);
                    CommandInvoker.instance.AddCommand(command);
                   // destination = transform.position + direction;

                    _speed = speed * speedMultiplyer;
                    isPushed = true;
                    //RoboController.instance.MovePlayer(direction);


                    //  Invoke("Grablastpos", 0f);
                }
            }
            // anim.SetBool("isMoving", isPushed);

            else
            {
                // transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            }


        }
    }

    private bool CheckDirection(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        // Debug.DrawRay(transform.position, direction);
        if (hit.collider != null)
        {
            return false;
            // string tag = hit.transform.tag;
            //if (hit.collider.gameObject.CompareTag("Pushable"))
            //{
            //    Debug.Log(tag);
            //    Debug.Log(hit);
            //    return false;
            //}

        }
        return true;
    }

    public void MoveBlock(Vector3 direction)
    {

        if(CheckDirectionAgain(direction)){

           // Debug.Log("Running");
            destination = transform.position + direction;
        }


    }
    public void PushAgain(Vector3 direction, float speed)
    {

        if (!isPushed)
        {
            if (CheckDirectionAgain(direction))
            {
                if (Vector3.Distance(RoboControllerRt.instance.transform.position, RoboControllerRt.instance.Destination) < Mathf.Epsilon)
                {
                    // Debug.Log("ImPushed");

                    //  ICommand move = new CommandMove(mPlayer, direction);
                    //   mInvoker.Execute(move);
                    //destination = mPlayer.transform.position;
                   
                    destination = transform.position + direction;

                    _speed = speed * speedMultiplyer;
                    isPushed = true;

                   // PlayerController.instance.MovePlayer(direction);
                    

                    //  Invoke("Grablastpos", 0f);
                }

                // anim.SetBool("isMoving", isPushed);
            }
            else
            {
                // transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            }
        }
    }
    private bool CheckDirectionAgain(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        // Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null)
        {


                    return false;
                

            
        }
        return true;

    }

    //private bool CheckDirectionForHook(Vector3 direction)
    //{

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction, detectionRadius, BlockMask);
    //    // Debug.Log(hit);


    //  //  Debug.DrawRay(transform.position, -direction);
    //    if (hit.collider != null)
    //    {

    //        if (!RoboController.instance.isStrong)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            if (RoboController.instance.isStrong)
    //            {
    //                return true;
    //            }

    //        }
    //        // string tag = hit.transform.tag;
    //        //if (hit.collider.gameObject.CompareTag("Pushable"))
    //        //{
    //        //    Debug.Log(tag);
    //        //    Debug.Log(hit);
    //        //    return false;
    //        //}

    //    }
    //    return true;
    //}


    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Robo1"))
    //    {
    //        other.gameObject.transform.parent = this.transform;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Robo1"))
    //    {
    //        //other.gameObject.transform.parent = this.transform;
    //    }
    //}


   
    


}
