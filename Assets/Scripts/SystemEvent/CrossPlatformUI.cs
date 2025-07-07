using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CrossPlatformUI : MonoBehaviour, IPointerClickHandler, ISubmitHandler
{
    [SerializeField] TextMeshProUGUI statusText;

    void Start()
    {
        var input = InputSystem.AddDevice<Gamepad>();
        if (input != null)
        {
            Debug.Log("Gamepad terdeteksi");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        statusText.text = "Tombol diklik dengan mouse/touch!";
    }

    public void OnSubmit(BaseEventData eventData)
    {
        statusText.text = "Tombol ditekan dengan controller!";
    }
}
