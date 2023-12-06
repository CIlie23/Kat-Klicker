using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public Text txtClicks;
    public Text txtCurrency;
    public int count; //i should have changed the name of this a LOOOOOOOOOOONG TIME AGO (e currency-ul din joc)
    public rankStuff rankStuff;
    public Button buttonOne;
    public Button btnPurchase;
    //public Sprite cookiestage1, cookiestage2, cookiestage3, cookiestage4;

    // Use this for initialization
   void Start () {
        count = SaveManager.instance.count;
        //timer = timer.GetComponent<rankStuff>();
        rankStuff = FindObjectOfType<rankStuff>();
        //buttonOne.onClick.AddListener(ChangeSprite);

        //btnPurchase.onClick.AddListener(removeClicks);
    }
	
	// Update is called once per frame
	void Update () {
        txtClicks.text = count.ToString("F0") + " Clicks";
        txtCurrency.text = count.ToString("F0") + " Clicks";
        SaveManager.instance.count = count;
        SaveManager.instance.Save();
    }

    /*public void removeClicks() //has to do with the shop
    {
        count -= 10;
        txtClicks.text = count.ToString("F0") + " Clicks";
        txtCurrency.text = count.ToString("F0") + " Clicks";
    }*/

    public void buttonClick()
    {
        count += 1;
        txtClicks.text = count.ToString("F0") + " Clicks";
        txtCurrency.text = count.ToString("F0") + " Clicks";
        //Debug.Log("You have clicked the button!");

        if (rankStuff != null)
        {
            // Basically, da call la ce e scris in rankStuff.cs, why did this take me so long
            rankStuff.IncreaseTimerByTen();
        }
        else
        {
            Debug.LogError("rankStuff script not found!");
        }
    }

   /* public void ChangeSprite() //disabled for now, I dont have the bowls ready D:
    {
        // Check the value of count and change the sprite accordingly
        if (count == 50)
        {
            buttonOne.image.sprite = cookiestage1;
        }
        else if (count == 250)
        {
            buttonOne.image.sprite = cookiestage2;
        }
        else if (count == 450)
        {
            buttonOne.image.sprite = cookiestage3;
        }
        else if (count == 650)
        {
            buttonOne.image.sprite = cookiestage4;
        }

    }*/
}
