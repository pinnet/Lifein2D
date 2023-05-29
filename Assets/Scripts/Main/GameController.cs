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
    [SerializeField] private Transform hilightPrefab; 

    private const string initialMessage = "Player One select your starting cells to begin and then press GO";
    private CellularAutomaton.Grid gameGrid;
    private GridSystem displayGrid;
    private GridPosition mousePosition;
    private GridPosition oldPosition;
    private bool gameStarted = false;
    private Transform hilight;
    private GridFrame[] gridFrameHistory;
    
    private int score = 0;
    private int moves = 0;

    private void Start()
    {
        gridFrameHistory = new GridFrame[gameBoard.totalGenerations];
        oldPosition = new GridPosition(int.MinValue, int.MinValue);
        displayGrid = new GridSystem(gameBoard.width, gameBoard.height, gameBoard.cellSize);
        hilight = GameObject.Instantiate(hilightPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        InitiliseGame();
    }
    
    void Update()
    {
        if (!gameStarted)
        {
            mousePosition = displayGrid.GetGridPosition(MouseWorld.GetPosition());
            if (mousePosition == oldPosition) return;
            oldPosition = mousePosition;
            bool cellVisible = (mousePosition.x >= 0 && mousePosition.x < gameBoard.width && mousePosition.z >= 0 && mousePosition.z < gameBoard.height);
            PlaceHilight(mousePosition.x, mousePosition.z, cellVisible);
        }
    }
    public void GameStart(Helpers.Events.Void value)
    {
        gameStarted = true;
        UpdateUI(moves: 0, status: "Game Started");
        for (int i = 0; i < gameBoard.totalGenerations; i++)
        {
            gridFrameHistory[i] = new GridFrame(gameGrid, i);
            gameGrid.Advance(player);
        }
        StartCoroutine(PlayGridHistory(.2f));
    }
    IEnumerator PlayGridHistory(float delay)
    {
        int generation = 0;
        while (generation < gameBoard.totalGenerations)
        {
            DisplayGrid(gridFrameHistory[generation++]);
            yield return new WaitForSeconds(delay);
        }
    }


    private void DisplayGrid(GridFrame frame)
    {
        ClearGrid();
        int noOfCells = 0;
        for (int x = 0; x < frame.Width; x++)
        {
            for (int y = 0; y < frame.Height; y++)
            {
                if (frame.Grid[x, y].Alive)
                {
                    Transform cell = GameObject.Instantiate(cellPrefab, displayGrid.GetWorldPosition(new GridPosition(x, y)), Quaternion.identity);
                    noOfCells++;
                }
            }
        }
        if(frame.Generation >= gameBoard.totalGenerations - 1 || noOfCells == 0)
        { 
            score += (frame.Generation * gameBoard.generationValue);
            GameOver();
        }
        else
        {
            score += noOfCells * gameBoard.cellValue;
            UpdateUI(score: score, generations: frame.Generation, status: $"Displaying Generation {frame.Generation}");
        }
        
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
    public void GameOver()
    {

        StopAllCoroutines();

        UpdateUI(score: score,status: $"Game Over you scored {score}") ;

    }

    public void GameRestart(Helpers.Events.Void value)
    {
        gameStarted = false;
        StopAllCoroutines();
        InitiliseGame();
        ClearGrid();
    }
    private void InitiliseGame()
    {
        gameGrid = new CellularAutomaton.Grid(gameBoard.width, gameBoard.height);
        moves = gameBoard.startingMoves;
        score = gameBoard.startingMoves * gameBoard.startingMoveCost;
        UpdateUI(score, gameBoard.startingMoves, null, initialMessage);
    }
    private void ClearGrid() 
    {
        CellAction action = new CellAction(0, 0);
        action.AllClear = true;
        cellActionEvent.Raise(action);
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
        
        if(generations != null)  data.generation = (generations == 0)? $"Generation : <Press GO>" : $"Generation : {generations}";
        else              data.generation = null;
                
        updateUI.Raise(data);
    }
    private void PlaceHilight(int x,int z,bool isVisible)
    {
        hilight.position = displayGrid.GetWorldPosition(new GridPosition(x, z));
        hilight.GetComponent<DisplayGridHilight>().SetVisibility(isVisible);
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
