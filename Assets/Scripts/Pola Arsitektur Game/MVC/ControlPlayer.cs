using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField] PlayerView view;
    PlayerModel model;
    Rigidbody rb;
    float moveSpeed = 5f;

    void Awake()
    {
        model = new PlayerModel();
        rb = GetComponent<Rigidbody>();
        UpdateView();
    }

    void FixedUpdate()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(movex, 0, movey).normalized;
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            model.AddScore(10);
            UpdateView();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            model.TakeDamage(20);
            UpdateView();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            model.AddScore(10);
            Destroy(other.gameObject);
            UpdateView();
        }
        else if (other.CompareTag("Enemy"))
        {
            model.TakeDamage(20);
            UpdateView();
        }
    }

    void UpdateView()
    {
        view.UpdateDisplay(model.Score, model.Health);
    }
}
