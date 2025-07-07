using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClickHandler : MonoBehaviour, IPointerClickHandler
{
    public delegate void ObjectClickedHandler(GameObject obj);
    public event ObjectClickedHandler OnObjectClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnObjectClicked?.Invoke(gameObject);
    }
}   
