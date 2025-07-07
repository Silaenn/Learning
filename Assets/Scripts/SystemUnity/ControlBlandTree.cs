using UnityEngine;

public class ControlBlandTree : MonoBehaviour
{
    private Animator animator;
    private float speed = 0f;

    [SerializeField] private float acceleration = 2f;  // seberapa cepat naik ke run
    [SerializeField] private float deceleration = 2f;  // seberapa cepat turun ke idle

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Tekan W untuk menambah speed, lepas untuk menguranginya
        bool isMoving = Input.GetKey(KeyCode.W);

        if (isMoving)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= deceleration * Time.deltaTime;
        }

        // Clamp biar speed tetap antara 0 dan 2
        speed = Mathf.Clamp(speed, 0f, 2f);

        // Kirim ke Animator
        animator.SetFloat("speed", speed);
    }
}
