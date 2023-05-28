using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro tmp;
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectedMaterial;

    public void onCellAction(CellAction action)
    {
        if(action.x !=1 || action.z != 1)
        {
            return;
        }
        Debug.Log(action.isSelected);
    }   
    
}
