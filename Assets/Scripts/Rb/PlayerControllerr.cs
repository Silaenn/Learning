using UnityEngine;
public class PlayerControllerr : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 10f;
    public float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // Bekukan rotasi
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * moveInput * moveForce);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}