using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPane : MonoBehaviour
{
    private int x, y; 
    private Renderer rendererObj;

    void Awake()
    {
        rendererObj = GetComponent<Renderer>();
        SetColor();
    }

    void OnMouseDown()
    {
        if(!enabled) return;
        
        switch(Board.NewGameBoard[x][y]){
            case PaneType.Empty: // Empty BLACK
                Board.NewGameBoard[x][y] = PaneType.Path;
                rendererObj.material.color = Color.gray;
                break;
            case PaneType.Path: // Path GREY
                Board.NewGameBoard[x][y] = PaneType.BuildingSpot;
                rendererObj.material.color = Color.white;
                break;
            case PaneType.BuildingSpot: // Build Spot WHITE
                Board.NewGameBoard[x][y] = PaneType.EnemyBase;
                rendererObj.material.color = Color.red;
                break;
            case PaneType.EnemyBase: // EnemyBase RED
                Board.NewGameBoard[x][y] = PaneType.PlayerBase;
                rendererObj.material.color = Color.green;
                break;
            case PaneType.PlayerBase: // PlayerBase GREEN
                Board.NewGameBoard[x][y] = PaneType.Empty;
                rendererObj.material.color = Color.black;
                break;
            default:
                Board.NewGameBoard[x][y] = PaneType.Empty;
                rendererObj.material.color = Color.black;
                break;
        }
        Debug.Log(Board.NewGameBoard[x][y] + $" {x},{y}");
    }

    public void SetCoordinates(int x, int y){
        this.x = x;
        this.y = y;
        SetColor();
    }

    private void SetColor()
    {
        switch(Board.NewGameBoard[x][y]){
            case PaneType.Empty: // Empty BLACK
                rendererObj.material.color = Color.black;
                break;
            case PaneType.Path: // Path GREY
                rendererObj.material.color = Color.grey;
                break;
            case PaneType.BuildingSpot: // Build Spot WHITE
                rendererObj.material.color = Color.white;
                break;
            case PaneType.EnemyBase: // EnemyBase RED
                rendererObj.material.color = Color.red;
                break;
            case PaneType.PlayerBase: // PlayerBase GREEN
                rendererObj.material.color = Color.green;
                break;
            default:
                rendererObj.material.color = Color.black;
                break;
        }
    }

}
