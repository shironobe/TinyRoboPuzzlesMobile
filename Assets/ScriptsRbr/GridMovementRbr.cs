using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovementRbr : MonoBehaviour
{
    public float speed;

    public bool isMoving;
    private Vector3 origPos, targetPos;

    private float timeToMove = 0.2f;

    private bool inContact;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
        StartCoroutine(movePlayer(Vector3.up));

          
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(movePlayer(Vector3.right));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(movePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(movePlayer(Vector3.left));
        }


    }
    private IEnumerator movePlayer(Vector3 direction)
    {
        isMoving = true;
        // transform.Translate(direction * speed * Time.deltaTime);

        float elapsedTime = 0f;

        origPos = transform.position;

        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private void OnTriggerstay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            inContact = true;
        }
    }
}
