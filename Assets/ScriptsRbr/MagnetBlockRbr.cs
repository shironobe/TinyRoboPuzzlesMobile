using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBlockRbr : MonoBehaviour
{
    // Start is called before the first frame update
    
    public LayerMask BlockMask = 0;
    public float detectionRadius;
    private Vector3 Destination;
    public float speed;

    public PushableBlockRbr pushableBlock;

    public PushableBlockRbr Robo2Block;


    void Start()
    {
        speed = 8f;
        pushableBlock = GetComponent<PushableBlockRbr>();
        Robo2Block = GameObject.FindGameObjectWithTag("Robo2").GetComponent<PushableBlockRbr>();

       
    }

    // Update is called once per frame
    void Update()
    {

       if ( Vector3.Distance(PlayerControllerRbr.instance.transform.position, PlayerControllerRbr.instance.Destination) < Mathf.Epsilon /*&& Vector3.Distance(Robo2Block.transform.position, Robo2Block.destination) < Mathf.Epsilon*/ )
        {
            CheckDirection(Vector3.right);
            CheckDirection(Vector3.left);
            CheckDirection(Vector3.up);
            CheckDirection(Vector3.down);

       }
    }
    private bool CheckDirection(Vector3 direction)
    {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);

   // Debug.DrawRay(transform.position, direction);

       

        if (hit)
        {
            string tag = hit.transform.tag;

            // Debug.Log(Vector3.Distance(transform.position, hit.transform.position));

            if (hit.collider.gameObject.CompareTag("Pushable") || hit.collider.gameObject.CompareTag("Robo2") || hit.collider.gameObject.CompareTag("PushableWoodBlock"))
            {

                PlayerControllerRbr.instance.canMove = false;
                PushableBlockRbr pushableBlock = hit.collider.GetComponent<PushableBlockRbr>();


                if (!pushableBlock)
                    return false;


             if (Vector3.Distance(pushableBlock.transform.position, pushableBlock.destination) < Mathf.Epsilon)
                {
                    if (!hit.collider.gameObject.CompareTag("PushableWoodBlock"))
                    {
                        pushableBlock.Hook(direction, speed);
                        PlayerControllerRbr.instance.canMove = true;
                    }
                }
                



            }

            return false;
        }


        return true;
    }



}
