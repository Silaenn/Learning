using UnityEngine;
using System.IO;

public class AssetBundleLoader : MonoBehaviour
{
    private AssetBundle cubeBundle;

    void Start()
    {
        LoadAssetBundle();
    }

    void LoadAssetBundle()
    {
        // Path ke AssetBundle
        string bundlePath = Path.Combine(Application.streamingAssetsPath, "cube");

        // Muat AssetBundle
        cubeBundle = AssetBundle.LoadFromFile(bundlePath);
        if (cubeBundle == null)
        {
            Debug.LogError("Gagal memuat AssetBundle dari path: " + bundlePath);
            return;
        }

        // Muat aset (misalnya, prefab bernama "Cube")
        GameObject cubePrefab = cubeBundle.LoadAsset<GameObject>("Cube");
        if (cubePrefab != null)
        {
            // Instansiasi prefab
            Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("Kubus berhasil dimuat dan diinstansiasi!");
        }
        else
        {
            Debug.LogError("Gagal memuat aset 'Cube' dari AssetBundle!");
        }
    }

    void OnDestroy()
    {
        // Unload AssetBundle untuk menghemat memori
        if (cubeBundle != null)
        {
            cubeBundle.Unload(false); // false = jangan hapus objek yang sudah diinstansiasi
            Debug.Log("AssetBundle di-unload.");
        }
    }
}