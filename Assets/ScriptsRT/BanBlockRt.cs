using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanBlockRt : MonoBehaviour
{

    public static BanBlockRt instance;
  public  BoxCollider2D block2d;

    public GameObject[] Bans;

    SpriteRenderer sr;

    public Sprite on, off;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Bans = GameObject.FindGameObjectsWithTag("Ban");


       

    }

    public void CheckBans()
    {

        for (int i = 0; i < Bans.Length; i++)
        {
          if( Bans[i].GetComponent<BanRt>().isRock)
            {
              //  AudioManager.instance.PlaySfx(5);
            }




        }

        foreach (GameObject Ban in Bans)
        {

            if (Ban.GetComponent<BanRt>().isRock)
            {

                block2d.enabled = false;
                sr.sprite = off;
              

            }
            else
            {
                block2d.enabled = true;
                sr.sprite = on;
                break;
            }
        }

    }





}
