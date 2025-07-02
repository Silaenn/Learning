using UnityEngine;
using System.Collections;

public class AttachRope : MonoBehaviour
{
    public RopeSimulation rope;
    public Rigidbody rbToAttach;

    void Start()
    {
        StartCoroutine(AttachNextFrame());
    }

    IEnumerator AttachNextFrame()
    {
        yield return null; 
        rope.AttachToRigidbody(rbToAttach);
    }
}
