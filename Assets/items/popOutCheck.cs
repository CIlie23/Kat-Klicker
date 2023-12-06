using UnityEngine;
using UnityEngine.UI;

public class popOutCheck : MonoBehaviour
{
    public SaveManager saveManager; 
    public Text catStatusText; 
    public Button btnPurchase;
    public int selectedCatIndex; 

    [Header("")]
    public test leMonies;
    public test leCurrency;
    public test leClicks;
    public itemDescriptions leSelectPrice;
    public itemDescriptions lePrice;

    void Start()
    {
        saveManager = SaveManager.instance;
        UpdateUIForPurchasedItems();
    }

    private void Update()
    {
        UpdateUIForPurchasedItems();

    }

    private void UpdateUIForPurchasedItems()
    {
        // Check if each cat is unlocked and update the UI accordingly
        for (int i = 0; i < saveManager.catsUnlocked.Length; i++)
        {
            if (saveManager.catsUnlocked[i])
            {
                // Cat is unlocked, update the UI (e.g., show the unlocked cat)
                //catStatusText.text = "Cat " + i + " is unlocked"; nu functioneaza cum trebuie momentan

                // If the selected cat is unlocked, disable the purchase button
                if (i == selectedCatIndex)
                {
                    btnPurchase.interactable = false;
                    //btnPurchase.gameObject.SetActive(false);
                }
            }
            else
            {
                // Cat is not unlocked, update the UI accordingly (e.g., show locked state)
                //catStatusText.text = "Cat " + i + " is locked";

                // If the selected cat is locked, enable the purchase button
                if (i == selectedCatIndex)
                {
                    btnPurchase.interactable = true;
                }
            }
        }
    }
    public void OnCatButtonClicked(int catIndex)
    {
        SetSelectedCat(catIndex);
    }
    
    public void SetSelectedCat(int catIndex) //btnEx1, btnEx2 si Btnex3
    {
        selectedCatIndex = catIndex;
    }

    public void PurchaseSelectedCat() //btnPutchase
    {
        // Check if the player has enough muneis to buy shiz
        if (selectedCatIndex >= 0 && selectedCatIndex < saveManager.catsUnlocked.Length &&
            !saveManager.catsUnlocked[selectedCatIndex] && saveManager.count >= lePrice.price[selectedCatIndex])
        {
            // Deduct the currency and mark the cat as purchased
            saveManager.count -= lePrice.price[selectedCatIndex];
            saveManager.catsUnlocked[selectedCatIndex] = true;

            UpdateUIForPurchasedItems();
        }
        else
        {
            Debug.Log("Asta ar trebui sa apara daca nu am bani");
        }
    }


}
