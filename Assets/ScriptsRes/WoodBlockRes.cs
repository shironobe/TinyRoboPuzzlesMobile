using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlockRes : MonoBehaviour
{
    public bool onLand;

    public Transform Contact;
    public LayerMask onLandCheck, PlayerLayer;

    public BoxCollider2D box2d;

    public bool isPlayerContact;

    public Sprite woodBlockOnLand, woodBlockInWater;

    SpriteRenderer sr;

    void Start()
    {
        box2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        onLand = Physics2D.OverlapCircle(Contact.position, 0.2f, onLandCheck);
        isPlayerContact = Physics2D.OverlapCircle(Contact.position, 0.2f, PlayerLayer);

        if (onLand)
        {
            sr.sprite = woodBlockOnLand;
        }
        else
        {
            if (!onLand)
            {
                sr.sprite = woodBlockInWater;
            }
        }
    }
}
