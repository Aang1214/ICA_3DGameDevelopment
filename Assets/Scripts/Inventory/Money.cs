using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public InventoryObject inventory;
    public TextMeshProUGUI moneyText;

    void Update()
    {
        if (inventory != null && moneyText != null)
        {
            moneyText.text = $"Money: {inventory.PlayerMoney}";
        }
    }
}
