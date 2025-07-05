using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] WeaponController weaponController;
    [SerializeField] TextMeshProUGUI ammoText;

    void Update()
    {
        ammoText.text = $"{weaponController.GetCurrentAmmo()}";
    }
}
