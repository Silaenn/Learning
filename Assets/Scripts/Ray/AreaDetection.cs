using UnityEngine;
public class AreaDetection : MonoBehaviour
{
    public float radius = 5f;
    public LayerMask detectLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.up, 0f, detectLayer);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log("Detected: " + hit.collider.name);
            }
        }
    }
}