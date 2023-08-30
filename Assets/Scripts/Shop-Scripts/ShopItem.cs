using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Outfit,
    Head
}

public enum ItemState
{
    ToBuy,
    Tosell,
    ToEquip,
}

[CreateAssetMenu(fileName = "Shop Item", menuName = "Shop Item/New shop item")]
public class ShopItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private float itemPrice;
    [SerializeField] private ItemType itemType;
    private ItemState itemState;

    public string GetItemName() => itemName;
    public Sprite GetItemSprite() => itemSprite;
    public float GetItemPrice() => itemPrice;
    public ItemType GetItemType() => itemType;
    public ItemState GetItemState() => itemState;
    public void SetItemState(ItemState state) => itemState = state;

}
