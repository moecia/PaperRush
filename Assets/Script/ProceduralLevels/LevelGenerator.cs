using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MapGenerator))]

public class LevelGenerator : MonoBehaviour {
    public MapGenerator mapGenerator;
    private List<Grid> currentGrids;

    public GameObject walls;
    public GameObject laneLeft;
    public GameObject laneMid;
    public GameObject landRight;

	// Use this for initialization
	void Start ()
    {
        currentGrids = mapGenerator.GetGrids();
        if(currentGrids != null)
        {
            for (int i = 0; i < currentGrids.Count; i++)
            {
                for (int j = 0; j < currentGrids[i].row; j++)
                {
                    for (int k = 0; k < currentGrids[i].col; k++)
                    {
                        switch (currentGrids[i].grid[j, k])
                        {
                            // Ground
                            case 0:
                                break;
                            // Walls
                            case 1:

                                break;
                        }
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
