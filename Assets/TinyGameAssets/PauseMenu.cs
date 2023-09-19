using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public bool muted, mutedSfx;

    public Image Audio, Music;
    public Sprite On, Off;
    public Sprite MusicOn, MusicOff;

    public GlobalAudioManager GlobalAudioManager;

    public Animator SceneTransition;

    public int CreditsScene;
    void Start()
    {
        PausePanel = GameObject.FindGameObjectWithTag("PausePanel");
        muted = (PlayerPrefs.GetInt("Muted") != 0);
        mutedSfx = (PlayerPrefs.GetInt("MutedSfx") != 0);
        updateMusicIcon();
        updateIcon();
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        AudioManagerRt.instance.PlaySfx(9);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManagerRt.instance.PlaySfx(9);

    }

    public void BackMenu()
    {
        // AudioManager.instance.PlaySfx(6);
        AudioManagerRt.instance.PlaySfx(9);
        Time.timeScale = 1f;
        GlobalAudioManager.instance.LoadBacktoMainScene();

        SceneManager.LoadScene(0);
    }

    public void MergeBotsBackMenu()
    {

    }

    public void RescueBotBackMenu()
    {

    }

    public void RobotwinsBackMenu()
    {

        AudioManagerRt.instance.PlaySfx(3);

        SceneManager.LoadScene(0);
    }
    public void StopSFX()
    {
      
        if (!mutedSfx)
        {
            GlobalAudioManager.instance.StopAllSfx();
            mutedSfx = true;
            GlobalAudioManager.instance.mutedSfx= true;
            PlayerPrefs.SetInt("MutedSfx", mutedSfx ? 1 : 0);
        }
        else
        {
            mutedSfx = false;
            GlobalAudioManager.instance.mutedSfx = false;
            PlayerPrefs.SetInt("MutedSfx", mutedSfx ? 1 : 0);

            GlobalAudioManager.instance.PlayAllSfx();
           
        }
        updateIcon();
       // Debug.Log("sfx");
       
    }

    public void StopMusic()
    {

        if (!muted)
        {
            GlobalAudioManager.instance.StopRobrosMusic();
            GlobalAudioManager.instance.StopMergeBotsMusic();
            GlobalAudioManager.instance.StopRescueBotMusic();
            GlobalAudioManager.instance.StopRoboTwinsMusic();


            if (SceneManager.GetActiveScene().buildIndex == 0 && SceneManager.GetActiveScene().buildIndex == 94)
            {
                GlobalAudioManager.instance.StopRoboTwinsMusic();
            }
            muted = true;
            GlobalAudioManager.instance.muted = true;
            PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
        }
        else
        {
            muted = false;
            GlobalAudioManager.instance.muted = false;
            PlayerPrefs.SetInt("Muted", muted ? 1 : 0);

            if (SceneManager.GetActiveScene().buildIndex < 24 && SceneManager.GetActiveScene().buildIndex > 0)
            {
                GlobalAudioManager.instance.StartRobrosMusic();
            }
            else if (SceneManager.GetActiveScene().buildIndex <= 45 && SceneManager.GetActiveScene().buildIndex >= 24)
            {
                GlobalAudioManager.instance.StartMergeBotsMusic();

            }
            else if (SceneManager.GetActiveScene().buildIndex <= 65 && SceneManager.GetActiveScene().buildIndex >= 46)
            {
                GlobalAudioManager.instance.StartRescueBotMusic();
            }
            else if (SceneManager.GetActiveScene().buildIndex <= 89 && SceneManager.GetActiveScene().buildIndex >= 66 ) { 
                GlobalAudioManager.instance.StartRoboTwinsMusic();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 94)
            {
                GlobalAudioManager.instance.StartRoboTwinsMusic();
            }
           




        }
        updateMusicIcon();
        //Debug.Log("music");
    }

    private void updateIcon()
    {
        if (!mutedSfx)
        {
            Audio.sprite = On;

        }
        else
        {
            if (mutedSfx)
            {
                Audio.sprite = Off;
            }

        }

       
    }
    private void updateMusicIcon()
    {
        if (!muted)
        {
            Music.sprite = MusicOn;

        }
        else
        {
            if (muted)
            {
                Music.sprite = MusicOff;
            }

        }

       
    }


    public void OpenCredits()
    {
        StartCoroutine(LoadCredits());
    }

    IEnumerator LoadCredits()
    {
        SceneTransition.SetTrigger("end");
        //  AudioManager.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(CreditsScene);
    }

}
