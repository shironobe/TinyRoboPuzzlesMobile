using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManagerRbr : MonoBehaviour
{
    public static AudioManagerRbr instance;

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
       
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SceneManager.LoadScene(0);

            }
        }

    }


    public void PlayMusic()
    {
        Sfx[0].Play();
        Sfx[0].volume = 0.5f;
    }
    public void PlaySfx(int Sfxno)
    {
        Sfx[Sfxno].Stop();

        Sfx[Sfxno].Play();
    }

    public void StopMusic()
    {

        Sfx[0].Stop();

        // updateMusicIcon();
    }

    public void StopSFX()
    {
      
            Sfx[1].volume = 0;
            Sfx[2].volume = 0;
            Sfx[3].volume = 0;
          Sfx[4].volume = 0;
            Sfx[5].volume = 0;
            Sfx[6].volume = 0;
       // Debug.Log("rbrsfxstoppeed");
           
       
       
       // updateIcon();
    }
    public void PlayAllSfx()
    {
        Sfx[1].volume = 0.35f;
        Sfx[2].volume = 0.35f;
        Sfx[3].volume = 0.35f;
        Sfx[4].volume = 0.35f;
        Sfx[5].volume = 0.35f;
        Sfx[6].volume = 0.35f;
       // PlaySfx(6);
    }
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
                AudioManagerRbr.instance.PlaySfx(5);
                muted = false;
                AudioListener.pause = false;
            }
        }
        //save();
        updateIcon();
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
}
