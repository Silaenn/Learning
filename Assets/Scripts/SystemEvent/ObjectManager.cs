using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    void Start()
    {
        ObjectClickHandler[] objects = FindObjectsOfType<ObjectClickHandler>();
        foreach (var obj in objects)
        {
            obj.OnObjectClicked += DestroyObject;
        }
    }

    void DestroyObject(GameObject obj)
    {
        Debug.Log($"Objek {obj.name} dihancurkan!");
        Destroy(obj);
    }

    void OnDestroy()
    {
        ObjectClickHandler[] objects = FindObjectsOfType<ObjectClickHandler>();
        foreach (var obj in objects)
        {
            obj.OnObjectClicked -= DestroyObject;
        }
        
    }
}
