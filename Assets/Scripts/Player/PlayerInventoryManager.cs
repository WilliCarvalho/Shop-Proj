using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static event Action<ShopItem> OnItemEquipped;
    [SerializeField] private Transform InventoryContainer;
    [SerializeField] private ShopItemDisplay InventoryItemPrefab;

    private List<ShopItem> currentInventoryItems = new List<ShopItem>();

    private void Awake()
    {
        print(currentInventoryItems.Count);
        PlayerData.OnInventoryChange += UploadInventoryItems;
    }

    private void UploadInventoryItems(List<ShopItem> list)
    {
        foreach (ShopItem item in list)
        {
            if ((currentInventoryItems.Count == 0 && currentInventoryItems.Contains(item)) || currentInventoryItems.Contains(item)) continue;
            ShopItemDisplay itemDisplay = Instantiate(InventoryItemPrefab, InventoryContainer);
            itemDisplay.OnTryBuySellEquipItem += OnInventoryItemEquip;
            itemDisplay.PopulateDisplay(item);
            currentInventoryItems.Add(item);
        }
    }

    public void OnInventoryItemEquip(ShopItem item)
    {
        currentInventoryItems.Remove(item);
        OnItemEquipped?.Invoke(item);
    }

    private void OnDisable()
    {
        PlayerData.OnInventoryChange -= UploadInventoryItems;
    }
}
