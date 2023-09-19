using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishRes : MonoBehaviour
{
    public static FinishRes instance;

    public Animator SceneTransition;

 

    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
      //  SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GreenBot")){

           
                //next level
               
                StartCoroutine(NextLevel());
                if (PlayerPrefs.GetInt("LevelUnlockRescuebot") < SceneManager.GetActiveScene().buildIndex + 1)
                {
                    PlayerPrefs.SetInt("LevelUnlockRescuebot", SceneManager.GetActiveScene().buildIndex + 1 - 45);
                }
            
        }
    }


   
    IEnumerator NextLevel()
    {

        // SceneTransition.SetTrigger("end");
        AudioManagerRes.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);
        if (SceneManager.GetActiveScene().buildIndex == 65)
        {
            SceneManager.LoadScene(94);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    
}
