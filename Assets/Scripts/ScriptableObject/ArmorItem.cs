using UnityEngine;

[CreateAssetMenu(fileName = "Armor Item", menuName = "Inventory/Items/New Armor Item")]
public class ArmorItem : ItemScriptableObject
{
    public BodyPart bodyPart;
    public int defensePoints;

}
public enum BodyPart 
{
    Head,
    Torso
}