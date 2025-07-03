using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventorySaveSystem : MonoBehaviour
{
    private string savePath;
    private Dictionary<int, Item> itemDictionary;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "inventory.txt");
        // Inisialisasi dictionary untuk item
        Item[] items = Resources.FindObjectsOfTypeAll<Item>();
        itemDictionary = new Dictionary<int, Item>();
        foreach (Item item in items)
        {
            int itemCode = Animator.StringToHash(item.id);
            itemDictionary[itemCode] = item;
        }
    }

    public void SaveInventory(List<InventoryItem> inventory)
    {
        using (StreamWriter writer = new StreamWriter(savePath))
        {
            foreach (InventoryItem invItem in inventory)
            {
                if (invItem.item != null)
                {
                    int itemCode = Animator.StringToHash(invItem.item.id);
                    writer.WriteLine($"{itemCode}|{invItem.quantity}");
                }
            }
        }
    }

    public Dictionary<Item, int> LoadInventory()
    {
        Dictionary<Item, int> loadedInventory = new Dictionary<Item, int>();
        if (File.Exists(savePath))
        {
            using (StreamReader reader = new StreamReader(savePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {   
                        if (int.TryParse(parts[0], out int itemCode) && int.TryParse(parts[1], out int quantity))
                        {
                            if (itemDictionary.TryGetValue(itemCode, out Item item))
                            {
                                loadedInventory[item] = quantity;
                            }
                        }
                    }
                }
            }
        }
        return loadedInventory;
    }
}