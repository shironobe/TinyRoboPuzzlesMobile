using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBoxRbr : MonoBehaviour
{
    private bool isHooked;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;
    private Vector3 destination;
    float _speed;
    float speedMultiplyer = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < Mathf.Epsilon)
        {
            transform.position = destination;
            isHooked = false;

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        }


    }
    public void Hook(Vector3 direction, float speed)
    {

        if (!isHooked)
        {
            if (CheckDirection(direction))
            {
                Debug.Log("ImPushed");
                destination = transform.position - direction;
                _speed = speed * speedMultiplyer;
                isHooked = true;
                // anim.SetBool("isMoving", isPushed);
            }
        }
    }

    private bool CheckDirection(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        Debug.DrawRay(transform.position, -direction);
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

