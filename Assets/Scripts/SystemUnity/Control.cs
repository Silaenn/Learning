using UnityEngine;

public class Control : MonoBehaviour
{
    Animator animator;
    float speed = 0.0f;

    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 2f;
    [SerializeField] float maxSpeed = 1.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Mathf.Abs(Input.GetAxis("Horizontal"));

        if (moveInput > 0.01f)
        {
            // Tambah kecepatan saat tombol ditekan
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            // Kurangi kecepatan saat tombol dilepas
            speed -= deceleration * Time.deltaTime;
        }

        // Clamp supaya tidak lebih dari maxSpeed atau kurang dari 0
        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        // Set parameter ke animator
        animator.SetFloat("speed", speed);
    }
}
