using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject cubePrefab;

    private const int PIRAMYD_COUNT = 5;
    private const int PIRAMYD_HEIGHT = 5;
    private const int PIRAMYD_BASE = PIRAMYD_HEIGHT * 2 - 1;

    void Start()
    {
        for (int x = 0; x < PIRAMYD_COUNT; x++)
        {
            for (int z = 0; z < PIRAMYD_COUNT; z++)
            {
                CreatePiramyd(new Vector3(x * PIRAMYD_BASE, 0f, z * PIRAMYD_BASE));
            }
        }
    }

    void Update()
    {
        
    }

    private void CreatePiramyd(Vector3 pos)
    {
        int offsetX = 0, offsetZ = 0;

        for (int y = 0; y < PIRAMYD_HEIGHT; y++)
        {
            for (int x = (int)pos.x + offsetX; x < pos.x + PIRAMYD_BASE - offsetX; x++)
            {
                for (int z = (int)pos.z + offsetZ; z < pos.z + PIRAMYD_BASE - offsetZ; z++)
                {
                    GameObject obj = Instantiate(cubePrefab, new Vector3(x + 0.5f, y + 0.5f, z + 0.5f), Quaternion.identity);
                    obj.transform.SetParent(transform);
                }
            }

            offsetX++;
            offsetZ++;
        }
    }
}
