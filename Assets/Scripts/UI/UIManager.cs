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
        changeInventoryUIState(false);
    }

    private void SetupListeners()
    {
        ShopKeeper.OnNearShopKeeper += ChangeShopUIState;
    }

    private void ChangeShopUIState(bool value)
    {
        ShopUI.SetActive(value);
    }

    private void changeInventoryUIState(bool value)
    {
        InventoryUI.SetActive(value);
    }
}
