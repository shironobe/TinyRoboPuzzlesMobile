using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportMe : MonoBehaviour
{
    public GameObject InAppPurchaseMenu;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenShopMenu()
    {
        if (!InAppPurchaseMenu.activeSelf)
        {
            InAppPurchaseMenu.SetActive(true);

        }
        else
        {
            InAppPurchaseMenu.SetActive(false);
        }
    }
}
