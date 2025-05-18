using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public InventoryObject inventory;
    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = $"Money: {inventory.PlayerMoney}";
    }
}
