using UnityEngine;

public class ControllerServiceLocator : MonoBehaviour
{
    [SerializeField] private GameInitializer gameInitializer;
    [SerializeField] private PlayerView view; // Dari MVC
    private PlayerModel model; // Dari MVC
    private Rigidbody rb;
    private IAudioService audioService;
    private float moveSpeed = 5f;

    private void Awake()
    {
        model = new PlayerModel();
        rb = GetComponent<Rigidbody>();
        audioService = ServiceLocator.GetService<IAudioService>();
        UpdateView();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            model.AddScore(10);
            audioService.PlaySound(gameInitializer.GetCoinClip());
            UpdateView();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            model.TakeDamage(20);
            audioService.PlaySound(gameInitializer.GetDamageClip());
            UpdateView();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            model.AddScore(10);
            audioService.PlaySound(gameInitializer.GetCoinClip());
            Destroy(other.gameObject);
            UpdateView();
        }
        else if (other.CompareTag("Enemy"))
        {
            model.TakeDamage(20);
            audioService.PlaySound(gameInitializer.GetDamageClip());
            UpdateView();
        }
    }

    private void UpdateView()
    {
        view.UpdateDisplay(model.Score, model.Health);
    }
}
