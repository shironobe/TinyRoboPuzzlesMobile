using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParentRbr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
            other.gameObject.transform.parent = this.gameObject.transform;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
            other.gameObject.transform.parent = null;
        }
    }
   
}
