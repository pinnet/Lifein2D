using CellularAutomaton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridFrame 
{
    private int width;
    private int height;
    private int generation;
    private CellularAutomaton.Grid grid;

    public int Width => width;
    public int Height => height;
    public int Generation => generation;
    public CellularAutomaton.Grid Grid => grid;

    public GridFrame(CellularAutomaton.Grid grid,int generation)
    {
        this.grid = grid;
        this.width = grid.Columns;
        this.height = grid.Rows;
        this.generation = generation;
    }   
}
