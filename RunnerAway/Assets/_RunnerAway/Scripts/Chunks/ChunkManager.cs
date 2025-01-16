using System;
using System.Collections;
using System.Collections.Generic;
using Chunks;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkManager : MonoBehaviour
{
    [Header("------ ELEMENTS ------")]
    [SerializeField] private Chunk[] chunkPrefabs;

    private void Start()
    {
        CreateChunk();
    }

    private void CreateChunk()
    {
        Vector3 chunkPosition = Vector3.zero;
        
        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
            if (i > 0)
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            
            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }
}
