using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRes : MonoBehaviour
{
    public bool isPlayerActive;

    public PlayerControllerRes PlayerControllerRes;

    public GreenBotRes GreenBotRes;

    public static ManagerRes instance;
    public GameObject SelectedRobo1, SelectedRobo2;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerControllerRes = GameObject.FindObjectOfType<PlayerControllerRes>();

        GreenBotRes = GameObject.FindObjectOfType<GreenBotRes>();

        SelectedRobo1 = GameObject.FindGameObjectWithTag("Selected1");
        SelectedRobo2 = GameObject.FindGameObjectWithTag("Selected2");
    }

    // Update is called once per frame
    void Update()
    {
        if (GreenBotRes.enabled == false)
        {

            SelectedRobo1.SetActive(true);
            SelectedRobo2.SetActive(false);
        }
        else
        {
            if (GreenBotRes.enabled == true)
            {

                SelectedRobo1.SetActive(false);
                SelectedRobo2.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GreenBotRes.instance.onRobo)
            {
                ChangeRobo();
            }
        }
    }

    public void ChangeRobo()
    {
        if (!GreenBotRes.instance.onRobo)
        {
            if (!isPlayerActive)
            {
                GreenBotRes.enabled = false;
                PlayerControllerRes.enabled = true;
                isPlayerActive = true;
                // AudioManagerRbr.instance.PlaySfx(3);
                // robo1RB.isKinematic = true;

            }
            else
            {
                if (isPlayerActive)
                {
                    GreenBotRes.enabled = true;
                    PlayerControllerRes.enabled = false;
                    isPlayerActive = false;
                    //  AudioManagerRbr.instance.PlaySfx(3);
                    // robo1RB.isKinematic = false;

                }
            }
        }
    }
}
