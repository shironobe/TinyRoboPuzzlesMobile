using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitLevelRbr : MonoBehaviour
{

//#if UNITY_WEBGL
   
//#endif
    int blocksPushed;
    public int blockNo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //for(int i = 0; i < Boxes.Length; i++)
        //{
        //    if (!Boxes[i].activeInHierarchy)
        //    {
        //        allBlocksOut = true;
        //      //  Debug.Log("LevelFinished");
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    }
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Pushable"))
        {
            other.gameObject.SetActive(false);
            blocksPushed++;
            AudioManagerRbr.instance.PlaySfx(2);
            if(blocksPushed >= blockNo)
            {
                //  Debug.Log("LevelFinished");
                // startlevel();
                if (SceneManager.GetActiveScene().buildIndex == 23)
                {
                    SceneManager.LoadScene(94);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                if (PlayerPrefs.GetInt("LevelUnlockRobros") < SceneManager.GetActiveScene().buildIndex + 1)
                {
                    PlayerPrefs.SetInt("LevelUnlockRobros", SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
           
        }
        //if (other.gameObject.CompareTag("Robo2"))
        //{
        //    Robo2Exited = true;
        //    other.gameObject.SetActive(false);
        //}

        //if (other.gameObject.CompareTag("Robo1") && !Robo2Exited)
        //{
        //    Debug.Log("Press R to Restart");
        //}

        //if (other.gameObject.CompareTag("Robo1") && !allBlocksOut)
        //{
        //    Debug.Log("Press R to Restart");
        //}


        //if (other.gameObject.CompareTag("Robo1") && Robo2Exited && allBlocksOut)
        //{
        //    Debug.Log("LevelFinished");
        //    other.gameObject.SetActive(false);
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //    PlayerPrefs.SetInt("LevelUnlock", SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }

   
}
