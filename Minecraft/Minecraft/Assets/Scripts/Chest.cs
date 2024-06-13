using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<ItemData> chestItems = new List<ItemData>();

    private void Start()
    {
        int itemCountChest = Random.Range(3, 7);
        for (int i = 0; i < itemCountChest; i++)
        {
            InventoryManager.instance.CreateItem(Random.Range(0, InventoryManager.instance.items.Length), chestItems);
        }
    }
}
