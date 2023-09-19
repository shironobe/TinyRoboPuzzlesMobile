using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRes : MonoBehaviour
{
    public static HoleRes instance;

    public GameObject HoleObject;
    public GameObject WoodBlock;

    public BoxCollider2D Box2D;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Box2D = GetComponent<BoxCollider2D>();
        HoleObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("RedBlock"))
        {


            other.gameObject.transform.position = transform.position;

            Animator anim = other.gameObject.GetComponent<Animator>();
             if (Vector3.Distance(other.gameObject.transform.position, transform.position) < Mathf.Epsilon)
            {
               // other.gameObject.GetComponent<PushableBlock>().enabled = false;
              //  other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetTrigger("fall");

                // other.gameObject.GetComponent<PushableBlock>().BlockMask =
                HoleObject.SetActive(false);
             //   AudioManager.instance.PlaySfx(4);
            }


        }
    }

    public void OffCollider()
    {
        Box2D.enabled = false;
    }
    public void OnCollider()
    {
        Box2D.enabled = true;
    }
}
