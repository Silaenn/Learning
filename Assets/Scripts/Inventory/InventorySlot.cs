using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler
{
    public InventoryItem item;
    private Image image;
    private Transform dragParent;

    private void Awake()
    {
        image = GetComponent<Image>();
        dragParent = GameObject.Find("Canvas").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            image.raycastTarget = false;
            transform.SetParent(dragParent);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            transform.position = eventData.position;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot sourceSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        if (sourceSlot != null && sourceSlot.item != null)
        {
            InventoryItem temp = item;
            item = sourceSlot.item;
            sourceSlot.item = temp;
            UpdateSlotUI();
            sourceSlot.UpdateSlotUI();
        }
    }

    public void UpdateSlotUI()
    {
        if (image == null)
    {
        Debug.LogWarning($"No Image component on {gameObject.name}");
        return;
    }
        image.sprite = item?.item.icon ?? null;
        image.enabled = item != null;
    }
}