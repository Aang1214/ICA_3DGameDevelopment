using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
//AI was used to write comments for the code
public class InventoryObject : ScriptableObject
{
    // List of all item slots currently in the inventory
    public List<InventorySlot> Container = new List<InventorySlot>();
    // Tracks the player's current money
    public int PlayerMoney { get; private set; }
    /// <summary>
    /// Adds an item to the inventory. If the item already exists, increase its amount.
    /// </summary>
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    /// <summary>
    /// Removes a specified amount of an item from the inventory.
    /// If removed, money is added based on the item's sell value.
    /// </summary>
    public bool RemoveItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].RemoveAmount(_amount);
                PlayerMoney += _item.sellValue * _amount;

                if (Container[i].amount <= 0)
                {
                    Container.RemoveAt(i);
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Resets the inventory and money to their default states.
    /// </summary>
    public void ResetInventory()
    {
        Container.Clear();
        PlayerMoney = 0;
    }
    /// <summary>
    /// Represents a single slot in the inventory, storing an item and its quantity.
    /// </summary>
    [System.Serializable]
    public class InventorySlot
    {
        public ItemObject item;
        public int amount;
        public InventorySlot(ItemObject _item, int _amount)
        {
            item = _item;
            amount = _amount;
        }
        public void AddAmount(int value)
        {
            amount += value;
        }
        public void RemoveAmount(int value)
        {
            amount -= value;
        }
    }
    /// <summary>
    /// Adds money to the player's total.
    /// </summary>
    public void AddMoney(int amount)
    {
        PlayerMoney += amount;
    }
    /// <summary>
    /// Reduces the player's money by a given amount.
    /// </summary>
    public void ReduceMoney(int amount)
    {
        PlayerMoney -= amount;
    }
}