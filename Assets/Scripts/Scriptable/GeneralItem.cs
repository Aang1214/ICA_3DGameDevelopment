using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Item/Default")]
public class GeneralItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.general;
    }
}
