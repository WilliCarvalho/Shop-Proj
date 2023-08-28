using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemImage;

    public ShopItem item { get; private set; }

    public void PopulateDisplay(ShopItem item)
    {
        this.itemName.text = item.GetItemName();
        this.itemPrice.text = item.GetItemPrice().ToString();
        this.itemImage.sprite = item.GetItemSprite();
        this.item = item;
    }
}
