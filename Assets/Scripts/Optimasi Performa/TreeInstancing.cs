using UnityEngine;

public class TreeInstancing : MonoBehaviour
{
    public Mesh treeMesh;
    public Material treeMaterial;
    private Matrix4x4[] matrices;
    public int instanceCount = 100;

    void Start()
    {
        matrices = new Matrix4x4[instanceCount];
        for (int i = 0; i < instanceCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-50f, 50f),
                0,
                Random.Range(-50f, 50f)
            );
            matrices[i] = Matrix4x4.TRS(position, Quaternion.identity, Vector3.one);
        }
    }

    void Update()
    {
        Graphics.DrawMeshInstanced(treeMesh, 0, treeMaterial, matrices);
    }

}
