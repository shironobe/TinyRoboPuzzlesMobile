using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager instance;

          

    public AudioSource[] Sfx;

    public bool muted, mutedSfx;

    public Image Audio, Music;
    public Sprite On, Off;
    public Sprite MusicOn, MusicOff;

  
    private void Awake()
    {


        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        muted = (PlayerPrefs.GetInt("Muted") != 0);
        mutedSfx = PlayerPrefs.GetInt("MutedSfx") != 0;

        if (mutedSfx)
        {
            StopAllSfx();
        }
        else
        {

        }
        if (!muted)
        {
            AudioManagerRt.instance.PlayMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
        muted = (PlayerPrefs.GetInt("Muted") != 0);
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }

    }


    public void LoadBacktoMainScene()
    {
      
        StopRobrosMusic();
        StopMergeBotsMusic();
        StopRescueBotMusic();
        // StopRoboTwinsMusic();
        if (!muted)
        {
            StartRoboTwinsMusic();
        }

    }
    public void StartRobrosMusic()
    {
        if (!muted) { 
            AudioManagerRbr.instance.PlayMusic();
          }
    }

    public void StartMergeBotsMusic()
    {
        if (!muted)
        {
            AudioManagerMerge.instance.PlayMusic();
        }
    }

    public void StartRescueBotMusic()
    {
        if (!muted)
        {
            AudioManagerRes.instance.PlayMusic();
        }
    }

    public void StartRoboTwinsMusic()
    {
        if (!muted)
        {
           AudioManagerRt.instance.PlayMusic();
        }
    }

    public void StopRobrosMusic()
    {
        AudioManagerRbr.instance.StopMusic();
    }

    public void StopMergeBotsMusic()
    {
        AudioManagerMerge.instance.StopMusic();
    }

    public void StopRescueBotMusic()
    {
        AudioManagerRes.instance.StopMusic();
    }

    public void StopRoboTwinsMusic()
    {
        AudioManagerRt.instance.StopMusic();
    }



    public void StopAllSfx()
    {
       
            AudioManagerRbr.instance.StopSFX();
            AudioManagerMerge.instance.StopSFX();
            AudioManagerRes.instance.StopSFX();
            AudioManagerRt.instance.StopSFX();
        
    }

    public void PlayAllSfx()
    {
        if (!mutedSfx)
        {
            AudioManagerRbr.instance.PlayAllSfx();
            AudioManagerMerge.instance.PlayAllSfx();
            AudioManagerRes.instance.PlayAllSfx();
            AudioManagerRt.instance.PlayAllSfx();
        }
    }
    //IEnumerator LoadMenuScene()
    //{
    //    SceneTransition.SetTrigger("end");
    //    AudioManagerRt.instance.PlaySfx(1);
    //    yield return new WaitForSeconds(0.10f);
    //    SceneManager.LoadScene(MainMenuScene);
    //}

}
