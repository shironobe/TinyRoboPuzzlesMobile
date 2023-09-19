using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtonRt : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite on, off;

    public bool isPressed;

  

    public GameObject blueDoor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {

           // AudioManager.instance.PlaySfx(3);
            AudioManagerRt.instance.PlaySfx(5);


        }
    }
        private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1") )
        {
            sr.sprite = on;
            isPressed = true;
            AudioManagerRt.instance.PlaySfx(3);
            AudioManagerRt.instance.PlaySfx(5);
            blueDoor.SetActive(false);
           
            //if (Input.GetKeyDown(KeyCode.Space) && Robo1.GetComponent<PlayerController>().enabled == true)
            //{

            //    Robo1.GetComponent<PlayerController>().enabled = false;

            //    Robo2.GetComponent<RoboController>().enabled = true;
            //}
        }
    }
}
