using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTheme : MonoBehaviour
{

    public static MenuTheme instance;
    public AudioSource MenuMusic;


    //#endif
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (!GlobalAudioManager.instance.muted)
        {
            MenuMusic.Play();
        }
    }

    // Update is called once per frame
   
}
