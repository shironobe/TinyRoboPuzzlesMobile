using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRb : MonoBehaviour
{
    // Start is called before the first frame update
    public SwitchRoboRt[] Buttons;
    void Start()
    {
        Buttons = GameObject.FindObjectsOfType<SwitchRoboRt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeRb()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {


            Buttons[i].SwitchRobo();

        }
    }

   

}
