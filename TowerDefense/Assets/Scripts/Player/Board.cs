using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static BoardData[] NewGameBoard;
    public  BoardData[] InspectorGameBoard;

    public GameObject[] fieldPrefabs; // 0: EditMode, 1: BuildingSpot, 2: Spawner
    //public GameObject[] enemyPrefabs; // will be used in edit mode
    public GameObject emptyBoardObject;

    public bool isEditMode = false;
    private float size = 2.5f;

    void Awake()
    {
        NewGameBoard = InspectorGameBoard;

        //case 0: Empty BLACK
        //case 1: Path GREY
        //case 2: Build Spot WHITE
        //case 3: EnemyBase RED
        //case 4: PlayerBase GREEN

        for (int x = 0; x < NewGameBoard.GetLength(0); x++)
        {
            for (int y = 0; y < NewGameBoard[x].GetLength(); y++)
            {
                if (NewGameBoard[x][y] == PaneType.EnemyBase) // WaveSpawner
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
                else if (NewGameBoard[x][y] == PaneType.BuildingSpot) // BuildingSpot
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
