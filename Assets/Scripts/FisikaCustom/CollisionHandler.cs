using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public SoftbodySimulation softbody; // Referensi ke skrip SoftbodySimulation
    public GameObject plane; // Referensi ke GameObject plane

    void FixedUpdate()
    {
        if (softbody != null && plane != null)
        {
            // softbody.HandleCollision(plane);
        }
    }
}