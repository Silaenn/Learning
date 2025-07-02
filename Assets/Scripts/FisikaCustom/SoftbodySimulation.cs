using UnityEngine;

public class SoftbodySimulation : MonoBehaviour
{
    private struct Vertex
    {
        public Vector3 position;
        public Vector3 prevPosition;
        public Vector3 velocity;
        public float mass;
    }

    [SerializeField] private float springConstant = 1000f;
    [SerializeField] private float damping = 0.1f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private int constraintIterations = 5;

    private Mesh mesh;
    private Vertex[] vertices;
    private Vector3[] originalVertices;
    private int[] triangles;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = new Vertex[mesh.vertexCount];
        originalVertices = mesh.vertices;
        triangles = mesh.triangles;

        for (int i = 0; i < mesh.vertexCount; i++)
        {
            vertices[i] = new Vertex
            {
                position = transform.TransformPoint(originalVertices[i]),
                prevPosition = transform.TransformPoint(originalVertices[i]),
                velocity = Vector3.zero,
                mass = 1f
            };
        }
    }

    void FixedUpdate()
    {
        Simulate();
        ApplyConstraints();
        UpdateMesh();
    }

    void Simulate()
    {
        float dt = Time.fixedDeltaTime;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 acceleration = new Vector3(0, -gravity, 0) / vertices[i].mass;

            // Verlet integration
            Vector3 newPosition = 2 * vertices[i].position - vertices[i].prevPosition + acceleration * dt * dt;
            vertices[i].prevPosition = vertices[i].position;
            vertices[i].position = newPosition;
        }
    }

    void ApplyConstraints()
    {
        for (int iter = 0; iter < constraintIterations; iter++)
        {
            for (int i = 0; i < triangles.Length; i += 3)
            {
                int v1 = triangles[i];
                int v2 = triangles[i + 1];
                int v3 = triangles[i + 2];

                // Batasan jarak antar vertex
                ApplyDistanceConstraint(v1, v2);
                ApplyDistanceConstraint(v2, v3);
                ApplyDistanceConstraint(v3, v1);
            }
        }
    }

    void ApplyDistanceConstraint(int i, int j)
    {
        Vector3 delta = vertices[j].position - vertices[i].position;
        float currentLength = delta.magnitude;
        float restLength = (transform.TransformPoint(originalVertices[j]) - transform.TransformPoint(originalVertices[i])).magnitude;
        float error = currentLength - restLength;

        Vector3 correction = delta.normalized * error * 0.5f;
        vertices[i].position += correction;
        vertices[j].position -= correction;
    }

    void UpdateMesh()
    {
        Vector3[] meshVertices = new Vector3[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            meshVertices[i] = transform.InverseTransformPoint(vertices[i].position);
        }
        mesh.vertices = meshVertices;
        mesh.RecalculateNormals();
    }

    // Deteksi tabrakan dengan Rigidbody
    public void HandleCollision(Rigidbody rb)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 closestPoint = rb.ClosestPointOnBounds(vertices[i].position);
            float distance = Vector3.Distance(closestPoint, vertices[i].position);

            if (distance < 0.1f) // Ambang tabrakan
            {
                Vector3 normal = (vertices[i].position - closestPoint).normalized;
                vertices[i].position = closestPoint + normal * 0.1f;
            }
        }
    }
}