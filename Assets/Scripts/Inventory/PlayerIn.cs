using System.Runtime.CompilerServices;
using UnityEngine;
using static InventoryObject; // Allows static access to members in InventoryObject (if needed)

public class PlayerIn : MonoBehaviour
{
    // Reference to the player's inventory system
    public InventoryObject inventory;

    // Read-only property to expose player's money if needed elsewhere
    public int PlayerMoney { get; private set; }

    // Called when another collider enters this GameObject's trigger collider
    public void OnTriggerEnter(Collider other)
    {
        // Try to get an Item component from the other object
        var item = other.GetComponent<Item>();

        // If it's a valid item and not tagged as an "ItemRemover"
        if (item && !other.CompareTag("ItemRemover"))
        {
            // Add the item to the inventory
            inventory.AddItem(item.item, 1);

            // Destroy the item GameObject after collecting
            Destroy(other.gameObject);
        }

        // If the object is an ItemRemover
        if (other.CompareTag("ItemRemover"))
        {
            ItemRemover remover = other.GetComponent<ItemRemover>();
            if (remover != null)
            {
                // Remove the specified item from the inventory
                inventory.RemoveItem(remover.itemToRemove, remover.amountToRemove);
            }
        }
    }

    // Reset inventory data when the application is closed or stopped in the editor
    private void OnApplicationQuit()
    {
        inventory.ResetInventory();
    }
}
