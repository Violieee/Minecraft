using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject groundPrefab, grassPrefab, chestPrefab;
    private int baseHeight = 2, maxBlockCountY = 10, chunkSize = 16,
        perlinNoiseSensivity = 25, chunkCount = 4;
    private float seedX, seedY;

    private void Start()
    {
        
    }

    [ContextMenu("CreateLevel")]
    private void CreateLevel()
    {
        seedX = Random.Range(0, 10);
        seedY = Random.Range(0, 10);
        for (int x = 0; x < chunkCount; x++)
        {
            for (int z = 0; z < chunkCount; z++)
            {
                CreateChunk(x, z);
            }
        }
    }

    private GameObject CreateChest(int x, int y, int z)
    {
        int createChance = Random.Range(0, 100);
        if(createChance > 98)
        {
            return Instantiate(chestPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
        return null;
    }

    private void CreateChunk(int chunkNumX, int chunkNumZ)
    {
        GameObject chunk = new GameObject();
        float chunkX = chunkNumX * chunkSize + chunkSize / 2;
        float chunkZ = chunkNumZ * chunkSize + chunkSize / 2;
        chunk.transform.position = new Vector3(chunkX, 0, chunkZ);
        chunk.name = $"Chunk: {chunkX}, {chunkZ}";
        chunk.AddComponent<Chunk>();
        chunk.AddComponent<MeshFilter>();
        chunk.AddComponent<MeshRenderer>();

        chunk.transform.SetParent(transform);

        for(int x = chunkNumX * chunkSize; x < chunkNumX * chunkSize + chunkSize; x++)
        {
            for (int z = chunkNumZ * chunkSize; z < chunkNumZ * chunkSize + chunkSize; z++)
            {
                float xSample = seedX + (float)x / perlinNoiseSensivity;
                float ySample = seedY + (float)z / perlinNoiseSensivity;
                float sample = Mathf.PerlinNoise(xSample, ySample);
                int height = baseHeight + (int)(sample * maxBlockCountY);

                for (int y = 0; y < height; y++) 
                {
                    GameObject obj = null;
                    if (y == height - 1)
                    {
                        obj = Instantiate(grassPrefab, new Vector3(x, y, z), Quaternion.identity);
                        GameObject chest = CreateChest(x, height, z);
                        if (chest != null)
                        {
                            chest.transform.SetParent(chunk.transform);
                        }
                    }
                    else
                    {
                        obj = Instantiate(groundPrefab, new Vector3(x, y, z), Quaternion.identity);
                    }
                    
                    obj.transform.SetParent(chunk.transform);
                }
            }
        }
    }
}
