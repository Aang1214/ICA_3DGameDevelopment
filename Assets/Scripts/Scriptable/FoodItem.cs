using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Item/Food")]
public class FoodItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.general;
    }
}
