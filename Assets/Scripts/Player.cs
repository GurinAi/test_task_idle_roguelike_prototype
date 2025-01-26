using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TMP_Text healthText;

    public ArmorItem headClothing;
    public ArmorItem torsoClothing;

    private Weapon selectedWeapon;
    private InventoryManager inventory;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
        inventory = GetComponent<InventoryManager>();
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateHealthDisplay();

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }
    private void UpdateHealthDisplay()
    {
        healthText.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }
    private void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void EquipClothing(ArmorItem clothing)
    {
        if (clothing.bodyPart == BodyPart.Head)
        {
            headClothing = clothing;
        }
        else if (clothing.bodyPart == BodyPart.Torso)
        {
            torsoClothing = clothing;
        }
    }

    // Выбор оружия
    public void SelectWeapon(Weapon weapon)
    {
        selectedWeapon = weapon;
    }
    public void Shoot()
    {
        if (selectedWeapon != null )
        {
            selectedWeapon.Shoot();
        }
    }

    // Проверка наличия боеприпасов для выбранного оружия
    /*private bool HasAmmo(Weapon weapon)
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.item is AmmoItem ammoItem && ammoItem.bulletType == weapon.type)
            {
                if (ammoItem.ammoCount >= weapon.ammoCost)
                {
                    ammoItem.ammoCount -= weapon.ammoCost;
                    return true;
                }
            }
        }
        return false;
    }*/
}