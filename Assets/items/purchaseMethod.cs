using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class purchaseMethod : MonoBehaviour
{

    public test leMonies;
    public test leCurrency;
    public test leClicks;
    public itemDescriptions leSelectPrice;
    public itemDescriptions lePrice;

    public Button btnEx1, btnEx2, btnEx3;
    private int currentCat;

    [Header("Popout")]
    [SerializeField]
    public Button btnPurchase;
    public Text txtLockedOne;
    public Text txtLockedTwo;
    public Text txtLockedThree;
    //public Text txtPrice;

    void Start()
    {
        // Load the game state when the game starts
        SaveManager.instance.Load();
    }
    void Update()
    {
        leClicks.txtClicks.text = leClicks.count.ToString("F0") + " Clicks";
        leCurrency.txtCurrency.text = leCurrency.count.ToString("F0") + " Clicks";
        UpdatePurchaseButton();
        SaveManager.instance.Save();
    }

    private void UpdatePurchaseButton()
    {
        btnPurchase.interactable = leMonies.count >= lePrice.price[0] || leMonies.count >= lePrice.price[1] || leMonies.count >= lePrice.price[2];
    }

    private bool IsItemPurchased(int itemIndex)
    {
        // Verifica daca itemul este deblocat in savemanager
       // return PlayerPrefs.GetInt("ItemPurchased_" + itemIndex, 0) == 1 || SaveManager.instance.catsUnlocked[itemIndex];
        return SaveManager.instance.catsUnlocked[itemIndex];
    }
    public void purchaseItemOne()
    {
        if (leMonies.count >= lePrice.price[0])
        {
            leMonies.count -= lePrice.price[0];
            SetItemPurchased(0); // Mark item one as purchased
            Debug.Log("Item one has been purchased");
            txtLockedOne.text = "";
            //txtPrice.text = "";
        }
        UpdatePurchaseButton();
    }


    public void purchaseItemTwo()
    {
        if (leMonies.count >= lePrice.price[1])
        {
            leMonies.count -= lePrice.price[1];
            SetItemPurchased(1); // Mark item two as purchased
            Debug.Log("Item two has been purchased");
            txtLockedTwo.text = "";
            //txtPrice.text = "";
        }
        UpdatePurchaseButton();
    }

    public void purchaseItemThree()
    {
        if (leMonies.count >= lePrice.price[2])
        {
            leMonies.count -= lePrice.price[2];
            SetItemPurchased(2); // Mark item three as purchased
            Debug.Log("Item three has been purchased");
            txtLockedThree.text = "";
            //txtPrice.text = "";
        }
        UpdatePurchaseButton();
    }

    private void SetItemPurchased(int itemIndex)
    {
        // Mark the item as purchased in both PlayerPrefs and SaveManager
        PlayerPrefs.SetInt("ItemPurchased_" + itemIndex, 1);
        SaveManager.instance.catsUnlocked[itemIndex] = true;
    }


}

//Singura problema pe care o am cu codul asta este ca nu tine cont de celelalte preturi, daca poti sa cumperi primul item, butonul de purchase o sa
//fie enabled la celelalte. Nu o sa poti cumpara nimic pentru ca nu ai banii necesari, dar ma enerveaza ca nu isi dau disable. O solutie care imi
//vine acuma ar fi sa fac un purchase button pentru fiecare, dar nu vreau sa fac asta. Eh I will think bout it later. ¯\_(ツ)_/¯
//Probabil trebuie sa pun asta in "itemDescriptions.cs" ?? Nu vreau sa ma gandesc la asta acum.

//btnPurchase.interactable = (SaveManager.instance.count >= leMonies.count[lePrice.price]);

// Placeholder, chestia asta da disable la butoanele cu itemele in ele
/*btnEx1.interactable = leMonies.count >= lePrice.price[0];
btnEx2.interactable = leMonies.count >= lePrice.price[1];
btnEx3.interactable = leMonies.count >= lePrice.price[2];*/

/*(if (SaveManager.instance.catsUnlocked[_index])
{
    btnPurchase.gameObject.SetActive(false);
}else
{
    btnPurchase.gameObject.SetActive(true);
}
SaveManager.instance.catsUnlocked[currentCat];
SaveManager.instance.Save();*/
