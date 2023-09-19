using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoPanel : MonoBehaviour
{
    public GameObject PauseMenu;

    public GameObject robros1info;


    void Start()
    {
        if (PlayerPrefs.HasKey("robros1"))
        {
            robros1info.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RobrosLevel()
    {
        if (!robros1info.activeSelf) { 
            robros1info.SetActive(true);
            PlayerPrefs.SetInt("robros1", 1);
        }
        else
        {
            robros1info.SetActive(false);
        }
       
    }
}
