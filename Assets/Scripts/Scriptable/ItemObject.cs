using UnityEngine;


public enum ItemType
{
    plastic,
    food,
    general,
    paper
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
