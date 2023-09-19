using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
public class LevelSelectMerge : MonoBehaviour
{
    public int LevelNo;

    Animator SceneTransition;


//#if UNITY_WEBGL
    
    void Start()
    {
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GotoLevel()
    {

        StartCoroutine(LoadLevel());
       //  startlevel();
    }
   
    IEnumerator LoadLevel()
    {

        SceneTransition.SetTrigger("end");
        AudioManagerMerge.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelNo);
    }



    
}
