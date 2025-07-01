using UnityEngine;

public class Torque3DTest : MonoBehaviour
{
    public float torqueStrength = 50f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddTorque(Vector3.up * torqueStrength);
        }
    }
}
