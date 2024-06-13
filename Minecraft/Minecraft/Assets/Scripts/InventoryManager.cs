using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private Transform tempParentForSlots;
    [SerializeField]
    private Text descriptionPanelText;
    [SerializeField]
    private GameObject slotPref, inventoryPanel, chestPanel, inventoryContent, chestContent, descriptionPanel;
    public ItemData[] items;
    public List<GameObject> inventorySlots = new List<GameObject>();
    public List<GameObject> currentChestSlots = new List<GameObject>();

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        inventoryPanel.SetActive(false);
        chestPanel.SetActive(false);
        descriptionPanel.SetActive(false);
    }

    public Transform GetTempParentForSlots()
    {
        return tempParentForSlots;
    }

    public Text GetDescriptionPanelText()
    {
        return descriptionPanelText;
    }

    public GameObject GetDescriptionPanel()
    {
        return descriptionPanel;
    }

    public GameObject GetInventoryPanel()
    {
        return inventoryPanel;
    }

    public GameObject GetChestPanel()
    {
        return chestPanel;
    }

    public GameObject GetInventoryContent()
    {
        return inventoryContent;
    }

    public GameObject GetChestContent()
    {
        return chestContent;
    }

    public void CreateItem(int itemId, List<ItemData> items)
    {
        ItemData item = new ItemData(this.items[itemId].name, 
                                     this.items[itemId].description, 
                                     this.items[itemId].id, 
                                     this.items[itemId].count, 
                                     this.items[itemId].isUniq);

        if (!item.isUniq && items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item.id == items[i].id)
                {
                    items[i].count += 1;
                    break;
                }
                else if (i == items.Count - 1)
                {
                    items.Add(item);
                    break;
                }
            }
        }
        else if (item.isUniq || (!item.isUniq && items.Count == 0))
        {
            items.Add(item);
        }
    }

    public void InstantiateItem(ItemData item, Transform parent, List<GameObject> items)
    {
        GameObject currentItem = Instantiate(slotPref);
        currentItem.transform.SetParent(parent);
        currentItem.AddComponent<Slot>();
        currentItem.GetComponent<Slot>().itemData = item;
        currentItem.transform.Find("ItemName").GetComponent<Text>().text = item.name;
        currentItem.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.name);
        currentItem.transform.Find("ItemCount").GetComponent<Text>().text = item.count.ToString();
        currentItem.transform.Find("ItemCount").GetComponent<Text>().color = 
            item.isUniq ? Color.clear : new Color(1, 0.6627451f, 0, 1);
        items.Add(currentItem);
    }
}
