using CellularAutomaton;
using Helpers.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerSO player;
    [SerializeField] private GameBoardSO gameBoard;
    [SerializeField] private UIUpdateEvent updateUI;
    [SerializeField] private CellActionEvent cellActionEvent;
    [SerializeField] private Transform cellPrefab;

    private CellularAutomaton.Grid gameGrid;
    private GridSystem displayGrid;
    private GridPosition mousePosition;
    private GridPosition oldPosition;
    private bool gameStarted = false;
    private Transform cell;


    private int score = 0;
    private int moves = 0;

    private void Start()
    {
        oldPosition = new GridPosition(int.MinValue, int.MinValue);
        gameGrid = new CellularAutomaton.Grid(gameBoard.width, gameBoard.height);
        displayGrid = new GridSystem(gameBoard.width, gameBoard.height, gameBoard.cellSize);
        moves = gameBoard.startingMoves;
        score = gameBoard.startingMoves * gameBoard.startingMoveCost;
        cell = GameObject.Instantiate(cellPrefab, new Vector3(0,0,0), Quaternion.identity);
        UpdateUI(score, gameBoard.startingMoves, null, "Player One select your starting cells to begin and then press GO");
    }

    void Update()
    {
        if(gameStarted) return;

        mousePosition = displayGrid.GetGridPosition(MouseWorld.GetPosition());
        if (mousePosition == oldPosition) return;
        oldPosition = mousePosition;
       
        //mousePosition.x = Mathf.Clamp(mousePosition.x, 0, gameBoard.width - 1);
        //mousePosition.z = Mathf.Clamp(mousePosition.z, 0, gameBoard.height - 1);
        bool cellVisible = (mousePosition.x >= 0 && mousePosition.x < gameBoard.width && mousePosition.z >= 0 && mousePosition.z < gameBoard.height);
        PlaceHilight(mousePosition.x, mousePosition.z, cellVisible);
    }
    public void OnMouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.phase != InputActionPhase.Performed) return;
        bool cellVisible = (mousePosition.x >= 0 && mousePosition.x < gameBoard.width && mousePosition.z >= 0 && mousePosition.z < gameBoard.height);
        
        if(cellVisible) toggleCell(mousePosition.x, mousePosition.z);

        
    }
    private void toggleCell(int x,int y)
    {
        
        GridPosition gridPosition = new GridPosition(x, y);
        if (!gameGrid[x,y].Alive)
        {
            if (moves <= 0) return;
            gameGrid[x, y].Owner = player;
            moves--;
            score -= gameBoard.startingMoveCost;
            Transform cell = GameObject.Instantiate(cellPrefab, displayGrid.GetWorldPosition(gridPosition), Quaternion.identity);
            cell.GetComponent<DisplayGridCell>().SetGridObject(displayGrid.GetGridObject(gridPosition));

            UpdateUI(score:score,moves:moves);
        }
        else
        {
            if(moves >= gameBoard.startingMoves) return;
            CellAction action = new CellAction(x, y);
            action.ToRemove = true;
            cellActionEvent.Raise(action);

            gameGrid[x, y].Owner = null;
            moves++;
            score += gameBoard.startingMoveCost;
            UpdateUI(score: score, moves: moves);
        }   
        
    }
    public void GameStart(Helpers.Events.Void value)
    {
        gameStarted = true;
        UpdateUI(moves:0,status:"Game Started");
    }

    private void UpdateUI(int? score = null,int? moves = null,int? generations = null,string? status = null)
    {
        UIData data = new UIData();

        if(moves  != null) data.startMoves = $"Starting Cells Remaining : {moves}";
        else               data.startMoves = null;
        
        if(score  != null) data.score = $"Score : {score}";
        else               data.score = null;
        
        if(status != null) data.status = status;
        else               data.status = null;
        
        if(generations != null)  data.generation = $"Generation : {generations}";
        else              data.generation = null;
                
        updateUI.Raise(data);
    }
    private void PlaceHilight(int x,int z,bool isVisible)
    {
        cell.position = displayGrid.GetWorldPosition(new GridPosition(x, z));
        cell.GetComponent<DisplayGridCell>().SetVisibility(isVisible);
    }
    public static int Min(int a, int b)
    {
        if (a > b)
            return b;
        return a;
    }
    public static int Max(int a, int b)
    {
        if (a > b)
            return a;
        return b;
    }
}
