using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

//namespace Samples.Purchasing.Core.IAPShop
public class IAPShop : MonoBehaviour
{
    private string DonationPizza1 = "com.kitarp.tinyrobopuzzles.donationpizza1";

    private string DonationPizza3 = "com.kitarp.tinyrobopuzzles.donationpizza3";

    private string DonationPizza5 = "com.kitarp.tinyrobopuzzles.donationpizza5";



    public GameObject Pizza1, thanks1, Pizza3, Thanks3, Pizza5, Thanks5;


    private void Start()
    {
      if(PlayerPrefs.GetInt("pizza1") == 1)
        {
            Pizza1.SetActive(false);
            thanks1.SetActive(true);
        }

        if (PlayerPrefs.GetInt("pizza3") == 3)
        {
            Pizza3.SetActive(false);
            Thanks3.SetActive(true);
        }

        if (PlayerPrefs.GetInt("pizza5") == 5)
        {
            Pizza5.SetActive(false);
            Thanks5.SetActive(true);
        }


    }

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == DonationPizza1)
        {
            //donation coffee
            Debug.Log("bought coffee");
            Pizza1.SetActive(false);
            thanks1.SetActive(true);
            PlayerPrefs.SetInt("pizza1", 1);
        }

        if (product.definition.id == DonationPizza3)
        {
            //donation coffee
            Debug.Log("bought coffee");

            Pizza3.SetActive(false);
           Thanks3.SetActive(true);
            PlayerPrefs.SetInt("pizza3", 3);
        }


        if (product.definition.id == DonationPizza5)
        {
            //donation coffee
            Debug.Log("bought coffee");
            Pizza5.SetActive(false);
            Thanks5.SetActive(true);
            PlayerPrefs.SetInt("pizza5", 5);
        }



    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + "failed because " + failureReason);
    }
}
