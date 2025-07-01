using UnityEngine;
public class Shooting : MonoBehaviour
{
    public float rayDistance = 100f;
    public LayerMask hitLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, hitLayer))
            {
                Debug.Log("Hit: " + hit.collider.name);
                // Tambahkan efek seperti menghancurkan musuh
            }
        }
    }
}