using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Reference to the InventoryObject that holds the player's money
    public InventoryObject inventory;

    // Reference to the TextMeshPro UI element that displays the money amount
    public TextMeshProUGUI moneyText;

    void Update()
    {
        // Update the UI text every frame with the current amount of money
        if (inventory != null && moneyText != null)
        {
            moneyText.text = $"Money: {inventory.PlayerMoney}";
        }
    }
}
