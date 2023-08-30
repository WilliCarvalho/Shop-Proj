using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShopKeeper : MonoBehaviour
{
    public static event Action<bool> OnNearShopKeeper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnNearShopKeeper?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnNearShopKeeper?.Invoke(false);
    }
}
