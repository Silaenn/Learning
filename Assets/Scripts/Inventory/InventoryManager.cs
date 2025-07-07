using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots; // Assign slot di Inspector
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public InventorySaveSystem saveSystem; // Assign di Inspector

    private void Start()
    {
        string[] itemNames = { "Sword", "Armor", "Health Potion", "Apple" };
        int[] quantities = { 1, 1, 5, 3 };

        for (int i = 0; i < itemNames.Length; i++)
        {
            InventoryItem newItem = new InventoryItem
            {
                item = Resources.Load<Item>(itemNames[i]),
                quantity = quantities[i],
                slotIndex = i
            };
            inventory.Add(newItem);
            slots[i].item = newItem;
            slots[i].UpdateSlotUI();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Tombol S untuk save
        {
            saveSystem.SaveInventory(inventory);
            Debug.Log("Inventory Saved");
        }
        if (Input.GetKeyDown(KeyCode.L)) // Tombol L untuk load
        {
            Dictionary<Item, int> loadedInventory = saveSystem.LoadInventory();
            inventory.Clear();
            int slotIndex = 0;  
            foreach (var pair in loadedInventory)
            {
                InventoryItem newItem = new InventoryItem
                {
                    item = pair.Key,
                    quantity = pair.Value,
                    slotIndex = slotIndex
                };
                inventory.Add(newItem);
                slots[slotIndex].item = newItem;
                slots[slotIndex].UpdateSlotUI();
                slotIndex++;
            }
            Debug.Log("Inventory Loaded");
        }
    }
}