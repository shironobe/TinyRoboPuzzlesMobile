using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNoAssignRt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text LevelNo;

    public int MinusScenes;
    void Start()
    {
        LevelNo = GetComponent<Text>();

        LevelNo.text = (SceneManager.GetActiveScene().buildIndex - MinusScenes).ToString();


    }

    // Update is called once per frame
    void Update()
    {
        LevelNo.text = (SceneManager.GetActiveScene().buildIndex - MinusScenes).ToString();
    }
}
