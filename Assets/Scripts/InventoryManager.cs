using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryContainer;
    public List<Slot> slots = new List<Slot>();

    private void Start()
    {
        for (int i = 0; i < inventoryContainer.childCount; i++)
        {
            slots.Add(inventoryContainer.GetChild(i).GetComponent<Slot>());
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (Slot slot in slots)
        {
            if (slot.item == _item)
            {
                if ((slot.amount + _amount) <= _item.maximumStackAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                else
                {
                    if (_amount != 1)
                    {
                        int missingQuantity = _item.maximumStackAmount - slot.amount;
                        _amount -= missingQuantity;

                        slot.amount += missingQuantity;
                        slot.itemAmountText.text = slot.amount.ToString();
                    }
                    continue;
                }
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.itemIcon);

                if (_amount == 1)
                    slot.itemAmountText.text = "";
                else
                    slot.itemAmountText.text = slot.amount.ToString();

                slot.itemGameObject.SetActive(true);
                return;
            }
        }
    }
}
