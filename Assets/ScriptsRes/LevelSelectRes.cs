using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
public class LevelSelectRes : MonoBehaviour
{
    public int LevelNo;

    Animator SceneTransition;


   
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
      
    }
    
    IEnumerator LoadLevel()
    {

        SceneTransition.SetTrigger("end");
        AudioManagerRes.instance.PlaySfx(1);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelNo);
    }



    
}
