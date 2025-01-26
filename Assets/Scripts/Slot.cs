using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Slot : MonoBehaviour, IDropHandler
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject itemGameObject;

    public Image itemImage;
    public TMP_Text itemAmountText;

    private void Awake()
    {
        itemImage = itemGameObject.transform.GetChild(0).GetComponent<Image>();
        itemAmountText = itemGameObject.transform.GetChild(1).GetComponent<TMP_Text>();

        if (item == null)
            itemGameObject.SetActive(false);
        else
            initStartItem();
    }

    public void SetIcon(Sprite icon)
    {
        itemImage.sprite = icon;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        DraggableItem draggableItem = otherItemTransform.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            int draggableItemSlotIndex = draggableItem.parentBeforeDrag.GetSiblingIndex();
            int currentSlotIndex = transform.GetSiblingIndex();

            draggableItem.parentBeforeDrag.SetSiblingIndex(currentSlotIndex);
            transform.SetSiblingIndex(draggableItemSlotIndex);
        }
    }

    public void SetEmptyValuesToSlot() 
    {
        item = null;
        amount = 0;
        isEmpty = true;
        itemGameObject.SetActive(false);
        itemImage.sprite = null;
        itemAmountText.text = "";
    }

    private void initStartItem()
    {
        itemImage.sprite = item.itemIcon;
        isEmpty = false;
        itemGameObject.SetActive(true);

        if (amount > item.maximumStackAmount || amount <= 1)
        {
            amount = 1;
            itemAmountText.text = "";
        }
        else
        {
            itemAmountText.text = amount.ToString();
        }
    }
}
