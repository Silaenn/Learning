[System.Serializable]
public class InventoryItem
{
    public Item item; // Referensi ke ScriptableObject
    public int quantity;
    public int slotIndex;
}