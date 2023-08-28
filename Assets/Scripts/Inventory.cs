using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private float coinBalance;
    [SerializeField] public List<ShopItem> items { get; private set; } = new List<ShopItem>();
}
