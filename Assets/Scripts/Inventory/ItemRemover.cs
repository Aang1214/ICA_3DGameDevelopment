using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    // The specific item to remove from the player's inventory when triggered
    public ItemObject itemToRemove;

    // The quantity of the item to remove
    public int amountToRemove = 1;
}
