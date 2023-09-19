using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerRes : MonoBehaviour
{
    int LevelUnlock;
    [SerializeField] Button[] LevelButtons;
    void Start()
    {
        LevelButtons = this.GetComponentsInChildren<Button>();
        LevelUnlock = PlayerPrefs.GetInt("LevelUnlockRescuebot", 1);

       
        if(LevelUnlock >= 20)
        {
            LevelUnlock = 20;
        }

        for (int i = 0; i < LevelButtons.Length; i++)
        {
       LevelButtons[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlock; i++)
        {
        LevelButtons[i].interactable = true;
        }

        
    }
  
    // Update is called once per frame



}
