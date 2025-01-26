using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupMenu : MonoBehaviour
{

    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemEffectText;
    [SerializeField] private TMP_Text itemWeightText;
    [SerializeField] private TMP_Text itemActionText;

    private Slot itemSlot;

    private int itemCount;
    private ItemType itemType;

    public void SetItemValues(Slot _itemSlot)
    {
        itemSlot = _itemSlot;
        itemCount = itemSlot.amount;
        itemImage.sprite = itemSlot.item.itemIcon;
        itemNameText.text = itemSlot.item.itemName;
        itemWeightText.text = itemSlot.item.itemWeightKG + " кг";

        if (itemSlot.item is MedicationItem medicationItem)
        {
            itemEffectText.text = "+" + medicationItem.healthRecoveryAmount + " зд";
            itemActionText.text = "Лечить";
            itemType = ItemType.Medication;
        }
        else if (itemSlot.item is ArmorItem armorItem)
        {
            itemEffectText.text = "+" + armorItem.defensePoints + " зщ";
            itemActionText.text = "Экипировать";
            itemType = ItemType.Armor;
        }
        else
        {
            itemEffectText.text = itemSlot.amount + " шт";
            itemActionText.text = "Купить";
            itemType = ItemType.Ammo;
        }
    }

    public void UseItem() 
    {
        if (itemSlot.item is MedicationItem medicationItem)
        {
            Debug.Log("Здоровье игрока повысилось на " + medicationItem.healthRecoveryAmount + " ед!");
            itemSlot.amount -= 1;

            if (itemSlot.amount <= 0)
            {
                DeleteItem();
            }
            else
            {
                if (itemSlot.amount != 1)
                    itemSlot.itemAmountText.text = itemSlot.amount.ToString();
                else
                    itemSlot.itemAmountText.text = "";
            }
        }
        else if (itemSlot.item is ArmorItem armorItem)
        {
            if (armorItem.bodyPart == BodyPart.Head) 
                Debug.Log("Защита головы повысилась на " + armorItem.defensePoints + " ед!");
            else
                Debug.Log("Защита торса повысилась на " + armorItem.defensePoints + " ед!");
            DeleteItem();
        }
        else if (itemSlot.item is AmmoItem ammoItem)
        {
            if (ammoItem.bulletType == BulletType.Pistol_Bullet)
                Debug.Log("Покупка патронов: " + ammoItem.itemName + " - " + itemSlot.amount + "шт!");
            else
                Debug.Log("Покупка патронов: " + ammoItem.itemName + " - " + itemSlot.amount + "шт!");
            DeleteItem();
        }
    }

    public void DeleteItem() 
    {
        itemSlot.SetEmptyValuesToSlot();
    }
}
