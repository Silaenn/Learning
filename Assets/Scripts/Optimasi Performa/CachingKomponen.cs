using UnityEngine;

public class CachingKomponen : MonoBehaviour
{
    Transform camTransform; // Cached Transform
    [SerializeField] float speed = 5f;

    void Start()
    {
        camTransform = GetComponent<Transform>(); // cache sekali di start
        if (camTransform == null)
        {
            Debug.LogError("Transform tidak ditemukan!");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        camTransform.Translate(moveX, 0, moveZ);
    }


}
