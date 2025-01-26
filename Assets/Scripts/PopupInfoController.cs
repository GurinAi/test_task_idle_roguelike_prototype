using UnityEngine;

public class PopupInfoController : MonoBehaviour
{
    [SerializeReference] private PopupMenu popupMenu;

    private GameObject popupPanel;
    private Slot slot;
    
    private void Awake()
    {
        popupPanel = popupMenu.transform.parent.gameObject;
        slot = gameObject.GetComponent<Slot>();
    }

    public void transferSlotInfoToPopup() 
    {
        if (slot.item != null)
        {
            popupMenu.SetItemValues(slot);
            popupPanel.SetActive(true);
        }
    }
}
