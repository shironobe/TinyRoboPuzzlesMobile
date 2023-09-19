using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject PauseMenu;

   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        AudioManagerRt.instance.PlaySfx(9);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;
        //PauseMenu.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
       // Time.timeScale = 0f;
        AudioManagerRt.instance.PlaySfx(9);
        PauseMenu.SetActive(true);
    }



   

    //IEnumerator Resetlvl()
    //{
    //    SceneTransition.SetTrigger("end");
    //    //  AudioManager.instance.PlaySfx(6);
    //    yield return new WaitForSeconds(0.10f);
    //    SceneManager.LoadScene(SceneNo);
    //}
}
