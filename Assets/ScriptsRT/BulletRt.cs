using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletRt : MonoBehaviour
{
    public float speed;
    public bool upDown;

    public bool up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!upDown)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        if (upDown)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pushable") )
        {
            Destroy(gameObject , 0.01f);
        }
        if ( other.gameObject.CompareTag("Ground") )
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("BanGate"))
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("BlueGate"))
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("Battery"))
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("Spikes"))
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("Outerwall"))
        {
            Destroy(gameObject, 0.01f);
        }

        if (other.gameObject.CompareTag("Robo2") || other.gameObject.CompareTag("Robo1"))
        {
            AudioManagerRt.instance.PlaySfx(8);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CommandInvoker.instance.ResetCounter();
        }


    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Pushable") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("BanGate") || other.gameObject.CompareTag("BlueGate") || other.gameObject.CompareTag("Battery") || other.gameObject.CompareTag("Spikes") || other.gameObject.CompareTag("Outerwall"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
