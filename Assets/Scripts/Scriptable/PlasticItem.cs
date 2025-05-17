using UnityEngine;
[CreateAssetMenu(fileName = "New Plastic Object", menuName = "Inventory System/Item/Plastic")]
public class PlasticItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.general;
    }
}