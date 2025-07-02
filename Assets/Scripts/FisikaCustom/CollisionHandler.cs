using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public SoftbodySimulation softbody; // Referensi ke skrip SoftbodySimulation
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        softbody.HandleCollision(rb);
    }
}