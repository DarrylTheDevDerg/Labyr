using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    [Header("Essential Info")]
    public int itemID;
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI quantityTxt;
    public GameObject shopManager;

    // Update is called once per frame
    void Start()
    {
        priceTxt.text = "Price: " + shopManager.GetComponent<ShopManagerScript>().shopItems[2, itemID].ToString();
        quantityTxt.text = shopManager.GetComponent<ShopManagerScript>().shopItems[3, itemID].ToString();
    }

    void Update()
    {
        priceTxt.text = "Price: " + shopManager.GetComponent<ShopManagerScript>().shopItems[2, itemID].ToString();
        quantityTxt.text = shopManager.GetComponent<ShopManagerScript>().shopItems[3, itemID].ToString();
    }
}
