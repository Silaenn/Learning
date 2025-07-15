using UnityEngine;
using UnityEditor;

public class CreateAssetBundle {
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles() {
        string outputPath = "Assets/AssetBundles";
        // Pastikan folder output ada
        if (!System.IO.Directory.Exists(outputPath)) {
            System.IO.Directory.CreateDirectory(outputPath);
        }
        // Build AssetBundle untuk platform tertentu
        BuildPipeline.BuildAssetBundles(outputPath, 
                                      BuildAssetBundleOptions.None, 
                                      BuildTarget.StandaloneWindows); // Ganti d     engan target platform, misalnya BuildTarget.Android
        Debug.Log("AssetBundles built successfully!");
    }
}