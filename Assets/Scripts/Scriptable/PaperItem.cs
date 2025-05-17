using UnityEngine;
[CreateAssetMenu(fileName = "New Paper Object", menuName = "Inventory System/item/Paper")]
public class PaperItem : Item
{
    public void Awake()
    {
        type = ItemType.paper;
    }
}
