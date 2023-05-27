using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameBoard"), System.Serializable]
public class GameBoardSO : ScriptableObject
{ 
    public int width;
    public int height;
    public float cellSize;        
}
