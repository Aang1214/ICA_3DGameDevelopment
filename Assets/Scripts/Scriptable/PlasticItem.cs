using UnityEngine;
[CreateAssetMenu(fileName = "New Plastic Object", menuName = "Inventory System/item/Plastic")]
public class PlasticItem : Item
{
    public void Awake()
    {
        type = ItemType.general;
    }
}