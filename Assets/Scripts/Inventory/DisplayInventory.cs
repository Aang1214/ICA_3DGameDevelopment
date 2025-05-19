using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static InventoryObject;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    // Reference to the inventory to display
    public InventoryObject inventory;

    // Horizontal space between each item in the UI grid
    public int X_SPACE_BETWEEN_ITEM;

    // Number of columns in the UI grid
    public int NUMBER_OF_COLUMN;

    // Vertical space between each item in the UI grid
    public int Y_SPACE_BETWEEN_ITEMS;

    // Dictionary to keep track of which inventory slots are displayed and their corresponding GameObjects
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Called once at the start to create the initial display
    void Start()
    {
        CreateDisplay();
    }

    // Called every frame to update the display (e.g., when inventory changes)
    void Update()
    {
        UpdateDisplay();
    }

    /// <summary>
    /// Updates the displayed inventory UI:
    /// - Removes UI objects for items no longer in the inventory.
    /// - Updates quantities for existing items.
    /// - Adds UI objects for new items.
    /// </summary>
    public void UpdateDisplay()
    {
        List<InventorySlot> keysToRemove = new List<InventorySlot>();

        // Find items that were removed from inventory and schedule their UI to be destroyed
        foreach (var kvp in itemsDisplayed)
        {
            if (!inventory.Container.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                keysToRemove.Add(kvp.Key);
            }
        }

        // Remove these items from the dictionary
        foreach (var key in keysToRemove)
        {
            itemsDisplayed.Remove(key);
        }

        // Loop through current inventory items
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // If item is already displayed, update the amount text
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text
                    = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                // Instantiate the UI prefab for the new item, position it, and set its amount text
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

                // Add the new item to the dictionary
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    /// <summary>
    /// Creates the initial display for all items currently in the inventory.
    /// </summary>
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    /// <summary>
    /// Calculates the position for an item UI element in a grid layout.
    /// </summary>
    /// <param name="i">Index of the item in the inventory list</param>
    /// <returns>Local position for the item UI element</returns>
    public Vector3 GetPosition(int i)
    {
        return new Vector3(
            X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN),           // X-position based on column
            -Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN),        // Y-position based on row (negative for downward layout)
            0f
        );
    }
}