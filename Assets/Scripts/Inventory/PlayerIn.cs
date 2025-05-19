using System.Runtime.CompilerServices;
using UnityEngine;
using static InventoryObject;
public class PlayerIn : MonoBehaviour
{
    public InventoryObject inventory;
    public int PlayerMoney { get; private set; }
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item && !other.CompareTag("ItemRemover"))
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ItemRemover"))
        {
            ItemRemover remover = other.GetComponent<ItemRemover>();
            if (remover != null)
            {
                inventory.RemoveItem(remover.itemToRemove, remover.amountToRemove);
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.ResetInventory();
    }

    
}
