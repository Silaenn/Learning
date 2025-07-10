using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    List<string> items = new List<string>();
    public int Capacity { get; set; }

    public InventorySystem(int capacity)
    {
        Capacity = capacity;
    }

    public bool AddItem(string item)
    {
        if (items.Count >= Capacity) return false;
        items.Add(item);
        return true;
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }
}
