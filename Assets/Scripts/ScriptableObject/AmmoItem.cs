using UnityEngine;

[CreateAssetMenu(fileName = "Ammo Item", menuName = "Inventory/Items/New Ammo Item")]
public class AmmoItem : ItemScriptableObject
{
    public BulletType bulletType;
}
public enum BulletType
{
    Pistol_Bullet,
    AKM_Bullet
}