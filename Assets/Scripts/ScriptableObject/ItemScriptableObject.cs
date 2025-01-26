using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;

    public Sprite itemIcon;
    public string itemName;
    public float itemWeightKG;

    public int amountInSet;
    public int maximumStackAmount;
}

public enum ItemType 
{
    Default,
    Medication,
    Armor,
    Ammo
}
