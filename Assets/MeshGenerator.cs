using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertecies;
    int[] triangles;

    int xSize = 5;
    int zSize = 5;

    public float xNoise;
    public float zNoise;
    public float NoiseMultiplier;

    Vector3 Offset;
    Vector2 NoiseOffset;

    public TerrainManager terrainManager;
    public int size = 1;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;


    }

    private void Update()
    {
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        xSize = terrainManager.ChunkSize * 3 * size;
        zSize = terrainManager.ChunkSize * 3 * size;
        Offset = new Vector3(-terrainManager.ChunkSize + terrainManager.PlayerPosX * terrainManager.ChunkSize, 0, -terrainManager.ChunkSize + terrainManager.PlayerPosZ * terrainManager.ChunkSize);
        NoiseOffset = new Vector2(terrainManager.PlayerPosX * terrainManager.ChunkSize * 0.3f, terrainManager.PlayerPosZ * terrainManager.ChunkSize * 0.3f);
        vertecies = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * xNoise + NoiseOffset.x, z * zNoise + NoiseOffset.y) * 2;
                vertecies[i] = new Vector3(x, y, z) + Offset;
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertecies;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
