using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    [Header("Essential Info")]
    public PlayerPrefsManager pointsManagement;
    public int[,] shopItems = new int[5,5];
    public int points;
    public TextMeshProUGUI pointsCounter;

    void Update()
    {
        points = pointsManagement.points;
        pointsCounter.text = $"Points: {points}";

        // ID Identifications
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Price Display
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        // Quantity in Inventory
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }

    public void BuyItem()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (points >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            points -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID]++;

            pointsCounter.text = $"Points: {points}";

            ButtonRef.GetComponent<ButtonInfo>().quantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID].ToString();

            pointsManagement.SavePrefs();

        }

    }
}
