using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField]
    private ToolTypes type;
    [SerializeField]
    private ToolMaterials tMaterial;
    public int damageToBlock { get; private set; }
    public int damageToEnemy { get; private set; }

    void Start()
    {
        damageToEnemy = (int)type * (int)tMaterial;
        switch (type)
        {
            case ToolTypes.PICKAXE:
                damageToBlock = 4 * (int)tMaterial;
                break;
            case ToolTypes.SWORD:
                damageToBlock = 1 * (int)tMaterial;
                break;
        }
    }

    void Update()
    {
        
    }
}
