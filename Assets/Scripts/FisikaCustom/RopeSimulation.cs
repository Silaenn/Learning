using System;
using UnityEngine;

public class RopeSimulation : MonoBehaviour
{
    struct Masspoint
    {
        public Vector3 position;
        public Vector3 prevPosition;
        public bool isFixed;
    }

    [SerializeField] int segmentCount = 10;
    [SerializeField] float segmentLength = 0.5f;
    [SerializeField] float mass = 1f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float springConstant = 1000f;
    [SerializeField] float damping = 0.1f;
    [SerializeField] int constraintIterations = 5;

    Masspoint[] points;
    Vector3[] connections;
    Rigidbody attachedRigidbody = null;

    void Start()
    {
        points = new Masspoint[segmentCount + 1];
        connections = new Vector3[segmentCount];

        for (int i = 0; i <= segmentCount; i++)
        {
            points[i] = new Masspoint
            {
                position = transform.position + Vector3.down * i * segmentLength,
                prevPosition = transform.position + Vector3.down * i * segmentLength,
                isFixed = (i == 0)
            };
        }

        for (int i = 0; i < segmentCount; i++)
        {
            connections[i] = points[i + 1].position - points[i].position;
        }

        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = segmentCount + 1;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
    }

    void FixedUpdate()
    {
        if (attachedRigidbody != null)
        {
            points[segmentCount].position = attachedRigidbody.position;
            points[segmentCount].prevPosition = attachedRigidbody.position;
        }

        Simulate();
        ApplyConstraints();
        UpdateLineRenderer();
    }

    void Simulate()
    {
        float dt = Time.fixedDeltaTime;

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].isFixed) continue;

            Vector3 acceleration = new Vector3(0, -gravity, 0) / mass;

            Vector3 velocity = (points[i].position - points[i].prevPosition) / dt;

            Vector3 newPosition = 2 * points[i].position - points[i].prevPosition + acceleration * dt * dt;

            points[i].prevPosition = points[i].position;
            points[i].position = newPosition;
        }
    }
    void ApplyConstraints()
    {
        for (int iter = 0; iter < constraintIterations; iter++)
        {
            for (int i = 0; i < segmentCount; i++)
            {
                Vector3 delta = points[i + 1].position - points[i].position;
                float currentLength = delta.magnitude;
                float error = currentLength - segmentLength;

                Vector3 correction = delta.normalized * error * 0.5f;

                if (!points[i].isFixed)
                    points[i].position += correction;
                if (!points[i + 1].isFixed)
                    points[i + 1].position -= correction;
            }
        }
    }

    void UpdateLineRenderer()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        for (int i = 0; i <= segmentCount; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }

    public void AttachToRigidbody(Rigidbody rb)
    {
         attachedRigidbody = rb;

        points[segmentCount].isFixed = true;
        points[segmentCount].position = rb.position;
        points[segmentCount].prevPosition = rb.position;
    }

}
