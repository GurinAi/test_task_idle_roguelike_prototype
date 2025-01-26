using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public int ammoCost;
    public BulletType type;

    public virtual void Shoot()
    {
        Debug.Log("Shooting with " + type.ToString());
    }

}