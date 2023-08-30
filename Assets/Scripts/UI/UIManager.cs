using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject InventoryUI;

    private void Awake()
    {
        SetupUI();
        SetupListeners();
    }

    private void SetupUI()
    {
        ChangeShopUIState(false);
        InventoryUI.SetActive(false);
    }

    private void SetupListeners()
    {
        ShopKeeper.OnNearShopKeeper += ChangeShopUIState;
        PlayerBehaviour.OnInventoryInputPressed += ChangeInventoryUIState;
    }

    private void ChangeShopUIState(bool value)
    {
        ShopUI.SetActive(value);
    }

    private void ChangeInventoryUIState()
    {
        if (InventoryUI.active)
        {
            InventoryUI.SetActive(false);
        }
        else
        {
            InventoryUI.SetActive(true);
        }
    }
}
