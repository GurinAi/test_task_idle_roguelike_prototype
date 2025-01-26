using UnityEngine;

public class Test : MonoBehaviour
{
    public ItemScriptableObject[] itemScriptableObjects;
    public InventoryManager InventoryManager;

    public void testAddItem() 
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(0, itemScriptableObjects.Length);
        InventoryManager.AddItem(itemScriptableObjects[randomNumber], itemScriptableObjects[randomNumber].amountInSet);
    }
}
