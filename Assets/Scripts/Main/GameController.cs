using Helpers.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerSO player;
    [SerializeField] private GameBoardSO gameBoard;
    [SerializeField] private UIUpdateEvent updateUI;

    private int score = 0;

    private void Start()
    {
        score = gameBoard.startingMoves * gameBoard.startingMoveCost;
        UIData data = new UIData();
        data.move = gameBoard.startingMoves;
        data.score = score;
        data.generation = null;
        data.status = "Player One select your starting cells to begin and then press GO";

        updateUI.Raise(data);
    }

    public void GameStart(Void value) { 
        
        UIData data = new UIData();
        data.move = 0;
        data.score = score;
        data.generation = 0;
        data.status = "Game Started";
        updateUI.Raise(data);
       }
}
