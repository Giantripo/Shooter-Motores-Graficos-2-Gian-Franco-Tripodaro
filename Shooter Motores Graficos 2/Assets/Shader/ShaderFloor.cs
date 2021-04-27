using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderFloor : MonoBehaviour
{
         Mesh mesh;
         MeshRenderer meshRenderer;
         MeshFilter meshFilter;
        List<Vector3> vertices;
        List<int> triangles;
        List<Vector2> uv;

    Vector3 offset;
    int triangleCounter = 0;


    public Material material;
    public Vector3 maxTiles = new Vector3(5, 0, 5);

   
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertices = new List<Vector3>();
        triangles = new List<int>();
        uv = new List<Vector2>();

        offset = new Vector3(0, 0, 0);
        triangleCounter = 0;

        for (int z = 0; z < maxTiles.z; z++)
        {
            offset.z = z;
            for (int x = 0; x < maxTiles.x; x++)
            {
                offset.x = x;

                vertices.Add(new Vector3(0, 0, 0) + offset);
                vertices.Add(new Vector3(0, 0, 1) + offset);
                vertices.Add(new Vector3(1, 0, 0) + offset);
                vertices.Add(new Vector3(1, 0, 1) + offset);

                triangles.AddRange(new int[] { 0 + triangleCounter, 1 + triangleCounter, 2 + triangleCounter });
                triangles.AddRange(new int[] { 2 + triangleCounter, 1 + triangleCounter, 3 + triangleCounter });

                uv.Add(new Vector2(0 + x , 0 + z));
                uv.Add(new Vector2(0 + x, 1 + z));
                uv.Add(new Vector2(1 + x, 0 + z));
                uv.Add(new Vector2(1 + x, 1 + z));

                triangleCounter += 4;
            } //forx
        } //forz
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();

        mesh.RecalculateNormals();
    }

   
    void Update()
    {
        
    }
}
