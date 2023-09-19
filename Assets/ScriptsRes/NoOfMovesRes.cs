using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoOfMovesRes : MonoBehaviour
{
    public Text Moves;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moves.text = PlayerControllerRes.instance.MoveNo.ToString();
    }
}
