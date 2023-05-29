using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem 
{ 
    
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    

    public GridSystem(int width, int height,float cellsize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellsize;

        gridObjectArray = new GridObject[width, height];    

        for (int x = 0; x < width; x++)
        {
            for(int z = 0; z < height; z++)
            {
                gridObjectArray[x,z] =  new GridObject(this, new GridPosition(x, z));
            }
        }
       
    }
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0,gridPosition.z) * cellSize;
    }
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
            );
    }
    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x,gridPosition.z];
    }
}
