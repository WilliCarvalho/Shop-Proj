using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static float moneyBalance { get; private set; }

    public static event Action<float> OnMoneyBalanceChange;
    public static event Action<List<ShopItem>> OnInventoryChange;

    [SerializeField] private Inventory playerInventory;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        moneyBalance += 999;
        ShopManager.OnShopItemPurchased += AddItemToInventory;
        ShopManager.OnShopItemSelled += RemoveItemfromInventory;
    }

    private void AddItemToInventory(ShopItem item)
    {
        item.SetItemState(ItemState.Tosell);
        playerInventory.GetItems().Add(item);
        OnInventoryChange?.Invoke(playerInventory.GetItems());
        SetPlayerMoneyBalance(-item.GetItemPrice());
    }

    private void RemoveItemfromInventory(ShopItem item)
    {
        item.SetItemState(ItemState.ToBuy);
        playerInventory.GetItems().Remove(item);
        OnInventoryChange?.Invoke(playerInventory.GetItems());
        SetPlayerMoneyBalance(item.GetItemPrice() / 2);
    }

    public void SetPlayerMoneyBalance(float newBalance)
    {
        moneyBalance += newBalance;
        OnMoneyBalanceChange?.Invoke(moneyBalance);
    }

    public List<ShopItem> GetplayerItems()
    {
        return playerInventory.GetItems();
    }
}
