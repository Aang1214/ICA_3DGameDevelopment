using UnityEngine;
[CreateAssetMenu(fileName = "New Paper Object", menuName = "Inventory System/Item/Paper")]
public class PaperItem : ItemObject
{
    public void Awake()
    {
        type = ItemType.paper;
    }
}
