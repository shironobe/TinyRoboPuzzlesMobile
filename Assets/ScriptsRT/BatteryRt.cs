using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatteryRT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robo1"))
        {
            //win

            StartCoroutine(NextLevel());

        }

        
    }


    IEnumerator NextLevel()
    {

        // SceneTransition.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
