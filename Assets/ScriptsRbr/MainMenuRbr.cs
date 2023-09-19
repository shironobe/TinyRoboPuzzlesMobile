using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuRbr : MonoBehaviour
{
    public int SceneNo;

    public bool muted;

    public Image Audio;
    public Sprite On, Off;

    public Animator SceneTransition;

    public int LevelScreen;

//#if UNITY_WEBGL
   

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

    

        if (!AudioManagerRbr.instance.Sfx[0].isPlaying)
        {
            AudioManagerRbr.instance.PlaySfx(0);
        }

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

    IEnumerator LoadScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManagerRbr.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(SceneNo);
    }

    IEnumerator LoadLevelScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManagerRbr.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelScreen);
    }
}
