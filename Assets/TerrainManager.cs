using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public int PlayerPosX;
    public int PlayerPosZ;

    public int ChunkSize = 10;
    public Transform Player;
    private void Update()
    {
        PlayerPosX = GetTransformInChunkPosX(Player);
        PlayerPosZ = GetTransformInChunkPosZ(Player);

        #region DebugChunks
        DrawChunk(PlayerPosX + 1, PlayerPosZ, Color.yellow);
        DrawChunk(PlayerPosX + 1, PlayerPosZ + 1, Color.yellow);
        DrawChunk(PlayerPosX + 1, PlayerPosZ - 1, Color.yellow);
        DrawChunk(PlayerPosX - 1, PlayerPosZ, Color.yellow);
        DrawChunk(PlayerPosX - 1, PlayerPosZ + 1, Color.yellow);
        DrawChunk(PlayerPosX - 1, PlayerPosZ - 1, Color.yellow);
        DrawChunk(PlayerPosX, PlayerPosZ + 1, Color.yellow);
        DrawChunk(PlayerPosX, PlayerPosZ - 1, Color.yellow);

        DrawChunk(PlayerPosX, PlayerPosZ, Color.green);
        #endregion


    }

    public void DrawChunk(int PosX, int PosZ, Color color)
    {
        //A-B
        Debug.DrawLine(new Vector3(PosX * ChunkSize, 0, PosZ * ChunkSize), new Vector3((PosX + 1) * ChunkSize, 0, PosZ * ChunkSize), color);

        //A-C
        Debug.DrawLine(new Vector3(PosX * ChunkSize, 0, PosZ * ChunkSize), new Vector3(PosX * ChunkSize, 0, (PosZ + 1) * ChunkSize), color);

        //B-D
        Debug.DrawLine(new Vector3((PosX + 1) * ChunkSize, 0, PosZ * ChunkSize), new Vector3((PosX + 1) * ChunkSize, 0, (PosZ + 1) * ChunkSize), color);

        //C-D
        Debug.DrawLine(new Vector3(PosX * ChunkSize, 0, (PosZ + 1) * ChunkSize), new Vector3((PosX + 1) * ChunkSize, 0, (PosZ + 1) * ChunkSize), color);
    }

    public int GetTransformInChunkPosX(Transform transform)
    {
        return (int)Mathf.Floor(transform.position.x / ChunkSize);
    }

    public int GetTransformInChunkPosZ(Transform transform)
    {
        return (int)Mathf.Floor(transform.position.z / ChunkSize);
    }
}
