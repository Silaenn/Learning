using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

public class AddressablesLoader : MonoBehaviour
{

    AsyncOperationHandle<GameObject> handle;
    void Start()
    {
        StartCoroutine(LoadAssetAsync());
    }

    IEnumerator LoadAssetAsync()
    {
        // Muat aset secara asinkronus menggunakan alamat
        handle = Addressables.LoadAssetAsync<GameObject>("Pedang");
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject cubePrefab = handle.Result;
            Instantiate(cubePrefab, new Vector3(0f,5,0), Quaternion.identity);
            Debug.Log("Kubus berhasil dimuat dari Addressables!");
        }
        else
        {
            Debug.LogError("Gagal memuat aset: " + handle.OperationException);
        }
    }

    void OnDestroy()
    {
        // Lepaskan aset untuk menghemat memori
        Addressables.Release(handle);
        Debug.Log("Aset dari Addressables di-release.");
    }
}