using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Outfit,
    Head,
}

[CreateAssetMenu(fileName = "Shop Item", menuName = "Shop Item/New shop item")]
public class ShopItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private float itemPrice;
    [SerializeField] private ItemType itemType;

    public string GetItemName() => itemName;
    public Sprite GetItemSprite() => itemSprite;
    public float GetItemPrice() => itemPrice;
    public ItemType GetItemType() => itemType;

}
