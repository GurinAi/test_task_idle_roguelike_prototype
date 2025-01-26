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
        itemWeightText.text = itemSlot.item.itemWeightKG + " ��";

        if (itemSlot.item is MedicationItem medicationItem)
        {
            itemEffectText.text = "+" + medicationItem.healthRecoveryAmount + " ��";
            itemActionText.text = "������";
            itemType = ItemType.Medication;
        }
        else if (itemSlot.item is ArmorItem armorItem)
        {
            itemEffectText.text = "+" + armorItem.defensePoints + " ��";
            itemActionText.text = "�����������";
            itemType = ItemType.Armor;
        }
        else
        {
            itemEffectText.text = itemSlot.amount + " ��";
            itemActionText.text = "������";
            itemType = ItemType.Ammo;
        }
    }

    public void UseItem() 
    {
        if (itemSlot.item is MedicationItem medicationItem)
        {
            Debug.Log("�������� ������ ���������� �� " + medicationItem.healthRecoveryAmount + " ��!");
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
                Debug.Log("������ ������ ���������� �� " + armorItem.defensePoints + " ��!");
            else
                Debug.Log("������ ����� ���������� �� " + armorItem.defensePoints + " ��!");
            DeleteItem();
        }
        else if (itemSlot.item is AmmoItem ammoItem)
        {
            if (ammoItem.bulletType == BulletType.Pistol_Bullet)
                Debug.Log("������� ��������: " + ammoItem.itemName + " - " + itemSlot.amount + "��!");
            else
                Debug.Log("������� ��������: " + ammoItem.itemName + " - " + itemSlot.amount + "��!");
            DeleteItem();
        }
    }

    public void DeleteItem() 
    {
        itemSlot.SetEmptyValuesToSlot();
    }
}
