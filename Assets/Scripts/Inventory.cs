using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ShopItem> items = new List<ShopItem>();

    public List<ShopItem> GetItems() => items;
}
