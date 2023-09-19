using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMerge : MonoBehaviour
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
        if (other.gameObject.CompareTag("Robo") || other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject, 0.2f);

            Invoke("Restart", 0.5f);
        }
        
    }


    void Restart()
    {
        PlayerControllerMerge.instance.RestartLevel();
    }
}
