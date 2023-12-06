using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemDescriptions : MonoBehaviour {

    public int selectedPrice;
    public GameObject popOut;
    public purchaseMethod purchases;
    public Button btnPurchase;

    [Header("UI")]
    public Button btnEx1, btnEx2, btnEx3;
    public Text txtLocked;
    //public Text txtLocked;

    [Header("Popout")]
    [SerializeField] private Text txtTitle;
    [SerializeField] private Text txtDescription;
    [SerializeField] private Text txtPrice;
    //[SerializeField] public Button btnPurchase;

    [Header("Item Prices")]
    [SerializeField] public int[] price;
    // Use this for initialization

    void Start () {
        btnEx1.onClick.AddListener(btnOneClicked);
        btnEx2.onClick.AddListener(btnTwoClicked);
        btnEx3.onClick.AddListener(btnThreeClicked);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btnOneClicked()
    {

        txtTitle.text = "El Gato";
        selectedPrice = price[0];
        txtPrice.text = "Price :" + selectedPrice;
        txtDescription.text = "A cute fun-sized fella ! Pick up with care";
        popOut.SetActive(true);

        if (popOut.activeSelf)
        {
            btnPurchase.onClick.RemoveAllListeners(); //clear the previous button instances so that it doesn't add up :x
            btnPurchase.onClick.AddListener(() => purchases.purchaseItemOne()); 
            Debug.Log("Popout is active");

        }
    }

    public void btnTwoClicked()
    {
        txtTitle.text = "Maxwell";
        selectedPrice = price[1];
        txtPrice.text = "Price :" + selectedPrice;
        txtDescription.text = "A distinguished gentleman, he shall spin his own way.";
        popOut.SetActive(true);

        if (popOut.activeSelf)
        {
            btnPurchase.onClick.RemoveAllListeners();
            btnPurchase.onClick.AddListener(() => purchases.purchaseItemTwo());
            Debug.Log("Popout is active");
        }
    }

    public void btnThreeClicked()
    {
        txtTitle.text = "Neco arc";
        selectedPrice = price[2];
        txtPrice.text = "Price :" + selectedPrice;
        txtDescription.text = "Pilk addict... how did she get here anyway?";
        popOut.SetActive(true);

        if (popOut.activeSelf)
        {
            btnPurchase.onClick.RemoveAllListeners();
            btnPurchase.onClick.AddListener(() => purchases.purchaseItemThree());
            Debug.Log("Popout is active");
        }
    }
}
