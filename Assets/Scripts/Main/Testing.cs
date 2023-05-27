using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform debugText;
    [SerializeField] private GameBoardSO gameBoard;
    
    
    private GridSystem grid;
    // Start is called before the first frame update
    void Start()
    {
        grid =  new GridSystem(gameBoard.width, gameBoard.height, gameBoard.cellSize);
        grid.CreateDebugObjects(debugText);
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(grid.GetGridPosition(MouseWorld.GetPosition()));
    }
}
