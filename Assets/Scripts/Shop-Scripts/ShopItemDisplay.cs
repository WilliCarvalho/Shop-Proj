using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    public event Action<ShopItem> OnTryBuySellEquipItem;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button buyButton;

    public ShopItem item { get; private set; }

    private void Awake()
    {
        buyButton.onClick.AddListener(TryBuySellItem);
    }

    private void TryBuySellItem()
    {
        OnTryBuySellEquipItem?.Invoke(item);
        Destroy(this.gameObject);
    }

    public void PopulateDisplay(ShopItem item)
    {
        this.itemName.text = item.GetItemName();
        this.itemPrice.text = item.GetItemPrice().ToString();
        this.itemImage.sprite = item.GetItemSprite();
        this.item = item;
    }

    public Button GetItemButton() => buyButton;
}
