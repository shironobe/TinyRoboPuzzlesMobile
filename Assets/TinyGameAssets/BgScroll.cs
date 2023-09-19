using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgScroll : MonoBehaviour
{
    public float speed;

    public Vector3 startPosition;

    public Vector3 currentPos;

    public float loopPos;

    
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
       currentPos = transform.position;
        //Vector3 worldpos = 
        if(transform.position.y < loopPos)
        {
            transform.position = startPosition;
        }
    }
}
