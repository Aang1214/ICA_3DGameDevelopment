using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/item/Default")]
public class GeneralItem : Item
{
    public void Awake()
    {
        type = ItemType.general;
    }
}
