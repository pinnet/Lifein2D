using CellularAutomaton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFrame 
{
    private int width;
    private int height;
    private int generation;
    private CellularAutomaton.Grid grid;

    public int Width => width;
    public int Height => height;
    public int Generation => generation;
    public CellularAutomaton.Grid Grid => grid;

    public GridFrame(CellularAutomaton.Grid data,int generation)
    {
        this.grid = new CellularAutomaton.Grid(data.Columns,data.Rows);
        this.width = data.Columns;
        this.height = data.Rows;
        this.generation = generation;


        for (int a = 0; a < data.Columns; a++)
        {
            for (int b = 0; b < data.Rows; b++)
            {
                this.grid[a, b] = data[a,b];
            }
        }


    }   
}
