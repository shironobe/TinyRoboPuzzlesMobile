using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMerge : MonoBehaviour
{
    public static HoleMerge instance;

    public GameObject HoleObject;
  

    public BoxCollider2D Box2D;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Robo") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("BombBot"))
        {


            other.gameObject.transform.position = transform.position;

            Animator anim = other.gameObject.GetComponent<Animator>();
             if (Vector3.Distance(other.gameObject.transform.position, transform.position) < Mathf.Epsilon)
            {
               // other.gameObject.GetComponent<PushableBlock>().enabled = false;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetTrigger("Fall");


                if (!other.gameObject.CompareTag("Pushable") && !other.gameObject.CompareTag("BombBot"))
                {
                    Destroy(other.gameObject, 0.2f);

                    AudioManagerMerge.instance.PlaySfx(4);
                    PlayerControllerMerge.instance.isDead = true;
                    Invoke("Restart", 0.5f);
                    
                }else if (other.gameObject.CompareTag("BombBot"))
                {
                    Destroy(other.gameObject, 0.2f);


                    AudioManagerMerge.instance.PlaySfx(4);


                }
                else
                {
                    if (other.gameObject.CompareTag("Pushable") )
                    {
                        AudioManagerMerge.instance.PlaySfx(3);
                        HoleObject.SetActive(false);
                        other.gameObject.GetComponent<PushableBlockMerge>().enabled = false;
                    }
                }
                // other.gameObject.GetComponent<PushableBlock>().BlockMask =
               // HoleObject.SetActive(false);
              //  AudioManager.instance.PlaySfx(4);
            }


        }
    }

    void Restart()
    {
        PlayerControllerMerge.instance.RestartLevel();
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
