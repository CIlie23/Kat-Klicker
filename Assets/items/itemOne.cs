using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class itemOne : MonoBehaviour {

    public Button btnEx1, btnEx2, btnEx3;
    public Text txtLocked;

    [Header("Popout")]
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Text txtPrice;
    [SerializeField] public Button btnPurchase;

    [Header("I have no clue")]
    [SerializeField] private int[] catPrices;
    private int currentCat;

    //public test countNumber;

    //public GameObject model1, model2;

    // Use this for initializations
    void Start () { //rememebr to add one for every button dumbass

        btnEx1.onClick.AddListener(btnOneClicked);
        btnEx2.onClick.AddListener(btnTwoClicked);
        btnEx3.onClick.AddListener(btnThreeClicked);

    }

    // Update is called once per frame
    void Update () {
        //Check if enough money
        btnPurchase.interactable = (SaveManager.instance.count >= catPrices[currentCat]);
    }

    public void selectCat(int _index)
    {
      /* for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }*/

        if (SaveManager.instance.catsUnlocked[_index])
        {
            btnPurchase.gameObject.SetActive(false);
            txtPrice.gameObject.SetActive(false);
        }
        else
        {
            btnPurchase.gameObject.SetActive(true);
            txtPrice.text = "Price : " + catPrices[_index];
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
/*if (SaveManager.instance.catsUnlocked[currentCat]) 
        {
            btnPurchase.gameObject.SetActive(false);
            txtPrice.gameObject.SetActive(false);
        }
        else
        {
            btnPurchase.gameObject.SetActive(true);
            txtPrice.text = "Price : " + catPrices[currentCat];
        }*/
    }
    public void buyCat()
    {
        SaveManager.instance.count -= catPrices[currentCat];
        SaveManager.instance.catsUnlocked[currentCat] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }

    public void btnOneClicked()
    {
        txtTitle.text = "This is item one!";
        txtDescription.text = "This is a description!";
       // Debug.Log("Button Clicked!");
       
    }

    public void btnTwoClicked()
    {
        txtTitle.text = "This is item two!";
        txtDescription.text = "This is a description of the second item!";
       // Debug.Log("Button Clicked!");
    }

    public void btnThreeClicked()
    {
        txtTitle.text = "This is item three!";
        txtDescription.text = "This is a description of the third item!";
        //Debug.Log("Button Clicked!");
    }
}
