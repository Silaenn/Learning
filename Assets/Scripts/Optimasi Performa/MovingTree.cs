using UnityEngine;

public class MovingTree : MonoBehaviour
{
    Transform treeTransform;

    void Start()
    {
        treeTransform = GetComponent<Transform>();
    }

    void Update()
    {
        treeTransform.Translate(-Vector3.forward * Time.deltaTime * 1f);
    }
}
