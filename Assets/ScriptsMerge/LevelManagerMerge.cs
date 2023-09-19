using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerMerge : MonoBehaviour
{
    int LevelUnlock;
    [SerializeField] Button[] LevelButtons;
    void Start()
    {
        LevelButtons = this.GetComponentsInChildren<Button>();
        LevelUnlock = PlayerPrefs.GetInt("LevelUnlockMerge", 1);

       
        if(LevelUnlock >= 22)
        {
            LevelUnlock = 22;
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
