using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanRt : MonoBehaviour
{
    public bool isRock;
    SpriteRenderer sr;

    public Sprite on, off;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
        {
            isRock = true;
            sr.sprite = on;
            BanBlockRt.instance.CheckBans();
        }
    }
    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
    //    {
    //        isRock = true;
    //        sr.sprite = on;
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
        {
            // AudioManager.instance.PlaySfx(5);
            BanBlockRt.instance.CheckBans();
        }
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
    //    {
    //        // AudioManager.instance.PlaySfx(5);
    //    }
    //}


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
        {
            isRock = false;
            sr.sprite = off;
        }
    }
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Robo2"))
    //    {
    //        isRock = false;
    //        sr.sprite = off;
    //    }
    //}
    



}
