using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameBoard"), System.Serializable]
public class GameBoardSO : ScriptableObject
{ 
    public int width;
    public int height;
    public float cellSize;
    public int cellValue;
    public int totalGenerations;
    public int startingMoves;
    public int startingMoveCost;
}
