using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int starting_move = 50;
    [SerializeField] int starting_Move_value = 100;
    [SerializeField] int cell_value = 10;
    [SerializeField] int score = 0;
    [SerializeField] private ScoreUpdateGameEventSO ScoreUpdate;
    [SerializeField] private MoveUpdateGameEventSO MoveUpdate;
    [SerializeField] private StatusUpdateGameEventSO StatusUpdate;
    [SerializeField] private OwnerSO player;

    private void Start()
    {
        MoveUpdate.Raise(starting_move);
        ScoreUpdate.Raise(score);
        StatusUpdate.Raise("Player 1 - play your opening move(s) then press GO");
    }


}
