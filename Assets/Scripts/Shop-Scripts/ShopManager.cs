using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static event Action<ShopItem> OnShopItemPurchased;
    public static event Action<ShopItem> OnShopItemSelled;

    [SerializeField] private Inventory shopInventory;
    [SerializeField] private TextMeshProUGUI buyResultText;
    [SerializeField] private TextMeshProUGUI moneyBalanceText;

    [Header("Shop prefabs")]
    [SerializeField] private ShopItemDisplay shopItemDisplayprefab;
    
    [Header("Containeres")]
    [SerializeField] private Transform BuyItemDisplayContainer;
    [SerializeField] private Transform SellItemDisplayContainer;

    private List<ShopItem> itemsToSell;
    private ShopItem lastBuySellItem;

    private void Awake()
    {
        PopulateBuyDisplay(shopInventory.GetItems());
        SetBuyResultText(false, "", Color.white);
        moneyBalanceText.text = PlayerData.moneyBalance.ToString();
        PlayerData.OnInventoryChange += PopulateSellDisplay;
        PlayerData.OnMoneyBalanceChange += UpdateMoneyBalanceText;
    }    

    private void PopulateBuyDisplay(List<ShopItem> items)
   {
        foreach (ShopItem shopItem in items)
        {
           if (lastBuySellItem != null && lastBuySellItem != shopItem) continue;
            ShopItemDisplay itemDisplay = Instantiate(shopItemDisplayprefab, BuyItemDisplayContainer);
            itemDisplay.OnTryBuySellItem += CheckItem;
            itemDisplay.PopulateDisplay(shopItem);
            shopItem.SetItemState(ItemState.ToBuy);
        }
    }

    private void PopulateSellDisplay(List<ShopItem> items)
    {        
        foreach (ShopItem item in items)
        {
            if (lastBuySellItem != null && lastBuySellItem != item) continue;
            ShopItemDisplay itemDisplay = Instantiate(shopItemDisplayprefab, SellItemDisplayContainer);
            itemDisplay.OnTryBuySellItem += CheckItem;
            itemDisplay.PopulateDisplay(item);
            item.SetItemState(ItemState.Tosell);
        }
        itemsToSell = items;
    }

    private void CheckItem(ShopItem item)
    {
        switch (item.GetItemState())
        {
            case ItemState.ToBuy:
                CheckIsPurchasable(item); 
                break;

            case ItemState.Tosell:
                SellItem(item);
                break;
        }
    }

    private void SellItem(ShopItem item)
    {
        Debug.Log("Item selled " + item.GetItemName());
        shopInventory.GetItems().Add(item);
        lastBuySellItem = item;
        PopulateBuyDisplay(shopInventory.GetItems());
        OnShopItemSelled?.Invoke(item);
        SetBuyResultText(true, "Successfuly Selled", Color.green);
    }

    private void CheckIsPurchasable(ShopItem item)
    {
        bool canBuy = PlayerData.moneyBalance >= item.GetItemPrice();

        if (canBuy)
        {
            SetBuyResultText(true, "Successfuly purchased", Color.green);
            shopInventory.GetItems().Remove(item);
            lastBuySellItem = item;
            OnShopItemPurchased?.Invoke(item);
        }
        else
        {
            SetBuyResultText(true, "You can't buy this item", Color.red);
        }
    }

    private void UpdateMoneyBalanceText(float newValue)
    {
        moneyBalanceText.text = newValue.ToString();
    }

    private void SetBuyResultText(bool value, string resultText, Color textColor)
    {
        buyResultText.text = resultText;
        buyResultText.color = textColor;
        buyResultText.gameObject.SetActive(value);
    }
}
