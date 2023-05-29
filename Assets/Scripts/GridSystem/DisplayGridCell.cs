using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Helpers.Events;

public class DisplayGridCell : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private Transform quad;
    private GridObject gridObject;
    private CellActionListener cellActionListener;

    public void SetVisibility(bool visibility)
    {

        if(visibility)
        {
            quad.gameObject.SetActive(true);
        }
        else
        {
            quad.gameObject.SetActive(false);
        }

    }

    private void Awake()
    {
        cellActionListener = GetComponent<CellActionListener>();    
    }

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        textMeshPro.text = gridObject.ToString();
    }
    public void Remove()
    {
        gameObject.SetActive(false);
        Destroy(gameObject,1f);
    }
    public void onCellAction(CellAction action)
    {
        if(gridObject == null) return;

        GridPosition gridPosition = gridObject.GetGridPosition();

        if (action.x != gridPosition.x || action.z != gridPosition.z)
        {
            return;
        }
        if (action.ToRemove) { Remove(); }
    }

}
