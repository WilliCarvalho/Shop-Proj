using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static event Action<ShopItem> OnItemEquipped;
    [SerializeField] private Transform InventoryContainer;
    [SerializeField] private ShopItemDisplay InventoryItemPrefab;

    private List<ShopItem> currentInventoryItems;

    private void Awake()
    {
        PlayerData.OnInventoryChange += UploadInventoryItems;
    }

    private void UploadInventoryItems(List<ShopItem> list)
    {
        print(list.Count);
        foreach (ShopItem item in list)
        {
            if (currentInventoryItems != null && currentInventoryItems.Contains(item)) continue;
            ShopItemDisplay itemDisplay = Instantiate(InventoryItemPrefab, InventoryContainer);
            itemDisplay.OnTryBuySellEquipItem += OnInventoryItemEquip;
            itemDisplay.PopulateDisplay(item);
        }
        currentInventoryItems = list;
    }

    public void OnInventoryItemEquip(ShopItem item)
    {
        OnItemEquipped?.Invoke(item);
    }
}
