using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
public class LevelSelectRbr : MonoBehaviour
{
    public int LevelNo;

    Animator SceneTransition;


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



    public void GotoLevel()
    {

        StartCoroutine(LoadLevel());
      //  startlevel();
    }
   
    IEnumerator LoadLevel()
    {

        SceneTransition.SetTrigger("end");
        AudioManagerRt.instance.PlaySfx(3);
        yield return new WaitForSeconds(0.32f);
        SceneManager.LoadScene(LevelNo);
    }
}
