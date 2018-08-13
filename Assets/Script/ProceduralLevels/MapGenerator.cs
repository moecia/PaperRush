using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public PlayerStatus playerStatus;
    public int difficulty = 1;
    public int coinsDensity = 1;
    public int maxGird = 10;

    private List<Grid> grids;
	// Use this for initialization
	void Start ()
    {
        grids = new List<Grid>(); 

        grids.Add(new Grid(difficulty, coinsDensity));
        grids.Add(new Grid(difficulty, coinsDensity));
        grids.Add(new Grid(difficulty, coinsDensity));
    }

    public List<Grid> GetGrids()
    {
        return grids;
    }
}

public class Grid
{
    public int[,] grid { get; private set; }
    public int col { get; private set; }
    public int row { get; private set; }

    public Grid(int difficulty, int coinsDensity)
    {
        col = 3;
        row = Random.Range(5, 11); 
        grid = new int[row, col];
        // Set walls and coins.
        int poseWallPos = Random.Range(0, 3);
        for (int i = 0; i < col; i++)
        {
            grid[0, i] = 1;
        }
        // Add coins
    }
}
