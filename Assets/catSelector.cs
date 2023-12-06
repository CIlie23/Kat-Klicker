using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class catSelector : MonoBehaviour {

    [Header("UI")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    [Header("Buyables")]
    [SerializeField] private Button btnPurchase;
    [SerializeField] private Text txtPrice;

    [Header("Cat prices")]
    [SerializeField] private int[] catPrices;
    private int currentCat;

    private void Start()
    {
        currentCat = SaveManager.instance.currentCat;
        selectCat(currentCat);
    }

    private void Awake()
    {
        selectCat(0);
    }
    private void selectCat(int _index)
    {

        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);
        for (int i = 0; i < transform.childCount; i++){
             transform.GetChild(i).gameObject.SetActive(i == _index);
         }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (SaveManager.instance.catsUnlocked[currentCat])
        {
            btnPurchase.gameObject.SetActive(false);
            txtPrice.gameObject.SetActive(false);
        }
        else
        {
            btnPurchase.gameObject.SetActive(true);
            txtPrice.text = "Price : " + catPrices[currentCat];
        }
    }

    private void Update()
    {
        if (btnPurchase.gameObject.activeInHierarchy)
        {
            btnPurchase.interactable = (SaveManager.instance.count >= catPrices[currentCat]);
        }
        //Check if enough money
       // btnPurchase.interactable = (SaveManager.instance.count >= catPrices[currentCat]);
    }

    public void changeCat(int _change)
    {
        currentCat += _change;

        if (currentCat > transform.childCount - 1)
            currentCat = 0;
        else if (currentCat < 0)
            currentCat = transform.childCount - 1;

        SaveManager.instance.currentCat = currentCat;
        SaveManager.instance.Save();
        selectCat(currentCat);
    }

    public void buyCat()
    {
        SaveManager.instance.count -= catPrices[currentCat];
        SaveManager.instance.catsUnlocked[currentCat] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
}
