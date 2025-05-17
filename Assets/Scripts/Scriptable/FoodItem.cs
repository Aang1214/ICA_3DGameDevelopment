using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/item/Food")]
public class FoodItem : Item
{
    public void Awake()
    {
        type = ItemType.general;
    }
}
