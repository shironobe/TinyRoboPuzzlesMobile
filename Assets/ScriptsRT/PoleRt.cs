using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleRt : MonoBehaviour
{
    public SpriteRenderer PoleRobo1;

    public GameObject Robo1, Robo2;
    public Sprite PoleOn, PoleOff;

    public GameObject Button;
    void Start()
    {
        Robo1 = GameObject.FindGameObjectWithTag("Robo1");

        Robo2 = GameObject.FindGameObjectWithTag("Robo2");

        PoleRobo1 = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Button.GetComponent<SwitchRobo>().isPressed && Robo2.GetComponent<RoboController>().enabled == false)
        //{

            
        //        PoleRobo1.sprite = PoleOn;
          
        //}
        //else
        //{
        //    if (!Button.GetComponent<SwitchRobo>().isPressed)
        //    {
        //        PoleRobo1.sprite = PoleOff;
        //    }
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
           
            if (Robo1.GetComponent<PlayerControllerRt>().enabled == true)
            {
                PoleRobo1.sprite = PoleOn;
            }
            //if (Input.GetKeyDown(KeyCode.Space) && Robo1.GetComponent<PlayerController>().enabled == true)
            //{

            //    Robo1.GetComponent<PlayerController>().enabled = false;

            //    Robo2.GetComponent<RoboController>().enabled = true;
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Robo1") && Robo1.GetComponent<PlayerControllerRt>().enabled == true)
        {

            
                PoleRobo1.sprite = PoleOn;
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
           

            PoleRobo1.sprite = PoleOff;
        }
    }
}
