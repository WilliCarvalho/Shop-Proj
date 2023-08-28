using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory shopInventory;
    [SerializeField] private Transform shopItemDisplayContainer;
    [SerializeField] private ShopItemDisplay shopItemDisplayprefab;

    private List<ShopItemDisplay> itemsToSell = new List<ShopItemDisplay>();

    private void Awake()
    {
        PopulateShopDisplay(shopInventory.items);
    }

    private void PopulateShopDisplay(List<ShopItem> items)
    {
        foreach (ShopItem shopItem in items)
        {
            ShopItemDisplay itemDisplay = Instantiate(shopItemDisplayprefab, shopItemDisplayContainer);
            itemDisplay.PopulateDisplay(shopItem);
            itemsToSell.Add(itemDisplay);            
        }        
        
    }
}
