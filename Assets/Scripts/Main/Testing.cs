using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform debugText;
    [SerializeField] private GameBoardSO gameBoard;
    [SerializeField] private CellActionEvent cellActionEvent;
    GridPosition mousePosition;
    GridPosition oldPosition;


    private GridSystem grid;
    // Start is called before the first frame update
    void Start()
    {
        grid =  new GridSystem(gameBoard.width, gameBoard.height, gameBoard.cellSize);
        grid.CreateDebugObjects(debugText);

        oldPosition = new GridPosition(int.MinValue,int.MinValue);
    }

    // Update is called once per frame
    void Update()
    { 
        mousePosition =  grid.GetGridPosition(MouseWorld.GetPosition());
        if (mousePosition == oldPosition) return;     
        oldPosition = mousePosition;
        UpdateCellAction(mousePosition.x, mousePosition.z);
        
    }
    private void UpdateCellAction(int x,int z)
    {
        CellAction action = new CellAction(x,z);
        Debug.Log($"New Cell Action Event {x},{z}");
        cellActionEvent.Raise(action);

    }
}
