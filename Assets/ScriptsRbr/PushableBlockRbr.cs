using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlockRbr : MonoBehaviour
{

    public static PushableBlockRbr instance;
    public bool isPushed;
    public bool isHooked;

    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;

    public Vector3 destination;
    public float _speed ;
    float speedMultiplyer = 1.5f;

    public bool shouldHook;

    public bool isDestroyable;

    Animator anim;

    public GameObject mPlayer;

    
    public PushableBlockRbr pushableBlockMagnet;


    
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        destination = transform.position;
        anim = GetComponent<Animator>();
        shouldHook = false;


        if (GameObject.FindObjectOfType<MagnetBlockRbr>() != null)
        {
            pushableBlockMagnet = GameObject.FindObjectOfType<MagnetBlockRbr>().GetComponent<PushableBlockRbr>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)



      




        if (Vector3.Distance(transform.position, destination) < Mathf.Epsilon)
            {

          
            transform.position = destination;

              isPushed = false;

              isHooked = false;
            

            PlayerControllerRbr.instance.canMove = true;

            }
            else
            {

            PlayerControllerRbr.instance.canMove = false;

      
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
                if (Vector3.Distance(PlayerControllerRbr.instance.transform.position, PlayerControllerRbr.instance.Destination) < Mathf.Epsilon)
                {
                    // Debug.Log("ImPushed");

               //ICommand move = new CommandMove(  mPlayer, direction);
               //mInvoker.Execute(move);
               //destination = mPlayer.transform.position;

             destination = transform.position + direction;

                    _speed = speed * speedMultiplyer;
                    isPushed = true;
                    PlayerControllerRbr.instance.MovePlayer(direction);
                    AudioManagerRbr.instance.PlaySfx(6);
                }

               // anim.SetBool("isMoving", isPushed);
            }
            else
            {
              //  transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            }
        }
    }

    private bool CheckDirection(Vector3 direction)
    {

       RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,  detectionRadius, BlockMask);
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

    public void Hook(Vector3 direction, float speed)
    {

        if (!isHooked )
        {
            if (CheckDirectionForHook(direction))
            {

                if (GameObject.FindObjectOfType<MagnetBlockRbr>() != null){
                    if (Vector3.Distance(pushableBlockMagnet.transform.position, pushableBlockMagnet.destination) < Mathf.Epsilon)
                    {

                        //ICommand move = new CommandMove(destination,  mPlayer, -direction);
                        //mInvoker.Execute(move);
                        //destination = mPlayer.transform.position;

                        destination = transform.position - direction;  //  Without Command Line 

                        _speed = speed * speedMultiplyer;
                        isHooked = true;
                        // }

                        // anim.SetBool("isMoving", isPushed);
                    }
                }else
                {
                    destination = transform.position - direction;  //  Without Command Line 

                    _speed = speed * speedMultiplyer;
                    isHooked = true;
                }
            }
        }
    }
    private bool CheckDirectionForHook(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


      //  Debug.DrawRay(transform.position, -direction);
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

}
