using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int health { get; set; }
    [SerializeField]
    private BlockTypes type;

    public void DestroyBehavior()
    {
        //GameObject miniBlock = Resources.Load<GameObject>("mini" + type.ToString());
        GameObject miniBlock = Resources.Load<GameObject>($"mini{type}");
        Instantiate(miniBlock, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Start()
    {
        health = (int)type;
    }

    private void Update()
    {
        
    }
}
