using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int SceneNo, RobrosLevelScene, MergeLevelScene, RescuebotLevelScene, RobotwinsLevelScene;

    public bool muted;

    public Image Audio;
    public Sprite On, Off;

    public Animator SceneTransition;

    public int LevelScreen;

 


  

   
    //#endif
    void Start()
    {
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayButton()
    {
        StartCoroutine(LoadLevelScene());



        AudioManagerRt.instance.PlaySfx(1);

    }
   

    public void PlayRobros()
    {

        StartCoroutine(RobrosLoadScene());
        GlobalAudioManager.instance.StopRoboTwinsMusic();
        GlobalAudioManager.instance.StartRobrosMusic();
    }

    public void PlayMergeBots()
    {
        StartCoroutine(MergeLoadScene());
        GlobalAudioManager.instance.StopRoboTwinsMusic();
        GlobalAudioManager.instance.StartMergeBotsMusic();
    }

    public void PlayRescueBot()
    {
        StartCoroutine(RescueBotLoadScene());
        GlobalAudioManager.instance.StopRoboTwinsMusic();
        GlobalAudioManager.instance.StartRescueBotMusic();
    }

    public void PlayRoboTwins()
    {
        StartCoroutine(RoboTwinsLoadScene());
       // GlobalAudioManager.instance.StartRoboTwinsMusic();
    }
    public void GotoScene()
    {
        StartCoroutine(LoadScene());
    }
   // private static extern void StartGameEvent();
    public void SoundOnOff()
    {

        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            if (muted)
            {
                muted = false;
                AudioListener.pause = false;
            }
        }
      //save();
     updateIcon();
    }
    private void updateIcon()
    {
        if (!muted)
        {
            Audio.sprite = On;

        }
        else
        {
            if (muted)
            {
                Audio.sprite = Off;
            }

        }
    }


    IEnumerator RobrosLoadScene()
    {
        SceneTransition.SetTrigger("end");
        //  AudioManager.instance.PlaySfx(6);
        AudioManagerRt.instance.PlaySfx(9);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(RobrosLevelScene);
    }

    IEnumerator MergeLoadScene()
    {
        SceneTransition.SetTrigger("end");
        //  AudioManager.instance.PlaySfx(6);
        AudioManagerRt.instance.PlaySfx(9);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(MergeLevelScene);
    }
    IEnumerator RescueBotLoadScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManagerRt.instance.PlaySfx(9);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(RescuebotLevelScene);
    }

    IEnumerator RoboTwinsLoadScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManagerRt.instance.PlaySfx(9);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(RobotwinsLevelScene);
    }

    IEnumerator LoadScene()
    {
       SceneTransition.SetTrigger("end");
      //  AudioManager.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(SceneNo);
    }

    IEnumerator LoadLevelScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManagerRt.instance.PlaySfx(1);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelScreen);
    }

    public void OpenPlaystore()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Kitarp.TinyRoboPuzzles");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/ShiroNobe");
    }
}
