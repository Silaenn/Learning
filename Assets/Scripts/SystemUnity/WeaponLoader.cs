using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class WeaponLoader : MonoBehaviour
{
    [SerializeField] string weaponAddress = "Weapon_Pedang";

    public async void LoadWeapon()
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(weaponAddress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject weapon = handle.Result;
            Instantiate(weapon, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Gagal memuat senjata");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadWeapon();
        }
    }
}
