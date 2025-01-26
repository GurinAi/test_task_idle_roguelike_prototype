using UnityEngine;

[CreateAssetMenu(fileName = "Medication Item", menuName = "Inventory/Items/New Medication Item")]
public class MedicationItem : ItemScriptableObject
{
    public int healthRecoveryAmount;   
}
