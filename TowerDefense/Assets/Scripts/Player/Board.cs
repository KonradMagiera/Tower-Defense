using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int[,] GameBoard;

    public GameObject[] fieldPrefabs; // 0: EditMode, 1: BuildingSpot, 2: Spawner
    public GameObject[] enemyPrefabs; // will be used in edit mode
    public GameObject emptyBoardObject;

    //public GameObject buildingSpotPrefab; // for placing turrets
    //public GameObject notScrpitedPrefab; // empty or road
    public bool isEditMode = false;
    private float size = 2.5f;

    void Awake()
    {
        //case 0: Empty BLACK
        //case 1: Path GREY
        //case 2: Build Spot WHITE
        //case 3: EnemyBase RED
        //case 4: PlayerBase GREEN

        GameBoard = new int[10, 10];
        GameBoard[0, 4] = 3;
        GameBoard[9, 4] = 4;
        GameBoard[8, 4] = 1;
        GameBoard[7, 4] = 1;
        GameBoard[6, 4] = 1;
        GameBoard[5, 4] = 1;
        GameBoard[4, 4] = 1;
        GameBoard[3, 4] = 1;
        GameBoard[3, 5] = 1;
        GameBoard[3, 6] = 1;
        GameBoard[2, 6] = 1;
        GameBoard[1, 6] = 1;
        GameBoard[1, 5] = 1;
        GameBoard[1, 3] = 1;
        GameBoard[2, 3] = 1;
        GameBoard[3, 3] = 1;
        GameBoard[1, 4] = 1;
        GameBoard[2, 4] = 2;
        GameBoard[4, 5] = 2;
        GameBoard[5, 5] = 2;
        GameBoard[6, 5] = 2;
        GameBoard[7, 5] = 2;
        GameBoard[8, 5] = 2;
        GameBoard[9, 5] = 2;


        for (int x = 0; x < GameBoard.GetLength(0); x++)
        {
            for (int y = 0; y < GameBoard.GetLength(1); y++)
            {
                if (GameBoard[x, y] == 3) // WaveSpawner
                {
                    // place manually in campgain: in custom map will be generated

                    // GameObject enemyBaseObject = (GameObject)Instantiate(fieldPrefabs[2], new Vector3(x * size - 5 * size, 0, y * size - 3 * size), Quaternion.identity);
                    // WaveSpawner spawner = enemyBaseObject.GetComponent<WaveSpawner>();
                    // spawner.SetPostionAndFindPath(x, y);
                    
                   // spawner.waves = new Wave[2];
                   // spawner.waves[0] = new Wave(1);
                   // spawner.waves[0].enemies[0].amount = 1;
                   // spawner.waves[0].enemies[0].spawnRate = 1;

                }
                else if (GameBoard[x, y] == 2) // BuildingSpot
                {
                    GameObject buildingSpotObject = (GameObject)Instantiate(fieldPrefabs[1], new Vector3(x * size - 5 * size, 0.1f, y * size - 3 * size), Quaternion.identity);
                    buildingSpotObject.transform.parent = emptyBoardObject.transform;

                }
                GameObject gridObject = (GameObject)Instantiate(fieldPrefabs[0], new Vector3(x * size - 5 * size, 0, y * size - 3 * size), Quaternion.identity);
                BoardPane pane = gridObject.GetComponent<BoardPane>();
                pane.SetCoordinates(x, y);
                gridObject.transform.parent = emptyBoardObject.transform;

                if (!isEditMode)
                {
                    pane.enabled = false;
                }

            }
        }
    }
}
