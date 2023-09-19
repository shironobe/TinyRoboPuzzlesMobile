using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerRbr : MonoBehaviour
{
    public static ManagerRbr instance;

    public ROBO2Rbr robo2;
    public PlayerControllerRbr playerController;

    public bool isRobo2Active;

    public Rigidbody2D robo1RB;

    public GameObject SelectedRobo1, SelectedRobo2;

    public bool Mobile;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        robo2 = GameObject.FindGameObjectWithTag("Robo2").GetComponent<ROBO2Rbr>();
        playerController = GameObject.FindGameObjectWithTag("Robo1").GetComponent<PlayerControllerRbr>();
        SelectedRobo1 = GameObject.FindGameObjectWithTag("sl1");
        SelectedRobo2 = GameObject.FindGameObjectWithTag("sl2");


    }

    // Update is called once per frame
    void Update()
    {


        if(robo2.enabled == false)
        {
           
            SelectedRobo1.SetActive(false);
            SelectedRobo2.SetActive(true);
        }
        else
        {
            if (robo2.enabled == true)
            {
               
                SelectedRobo1.SetActive(true);
                SelectedRobo2.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
          // replaylevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }




        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space)) {


            if (Vector3.Distance(PlayerControllerRbr.instance.transform.position, PlayerControllerRbr.instance.Destination) < Mathf.Epsilon)
            {
                if (isRobo2Active)
                {
                    robo2.enabled = false;
                    playerController.enabled = true;
                    isRobo2Active = false;
                    AudioManagerRbr.instance.PlaySfx(3);
                    // robo1RB.isKinematic = true;

                }
                else
                {
                    if (!isRobo2Active)
                    {
                        robo2.enabled = true;
                        playerController.enabled = false;
                        isRobo2Active = true;
                        AudioManagerRbr.instance.PlaySfx(3);
                        // robo1RB.isKinematic = false;

                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.X) )
            {
              
            }
        }
    }

   
    public void Up()
    {
        if (!isRobo2Active)
        {
            PlayerControllerRbr.instance.Up();
        }
        else
        {
            ROBO2Rbr.instance.UpMangent();
        }
    }

    public void ChangeRobo()
    {
        if (isRobo2Active)
        {
            robo2.enabled = false;
            playerController.enabled = true;
            isRobo2Active = false;
            AudioManagerRbr.instance.PlaySfx(3);
            // robo1RB.isKinematic = true;

        }
        else
        {
            if (!isRobo2Active)
            {
                robo2.enabled = true;
                playerController.enabled = false;
                isRobo2Active = true;
                AudioManagerRbr.instance.PlaySfx(3);
                // robo1RB.isKinematic = false;

            }
        }
    }
}
