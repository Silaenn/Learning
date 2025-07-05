using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 180f;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotateInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, moveInput);
        transform.Rotate(0, rotateInput, 0);
    }
}
