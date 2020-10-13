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
        switch(Board.GameBoard[x,y]){
            case 0: // Empty BLACK
                Board.GameBoard[x,y] = 1;
                rendererObj.material.color = Color.gray;
                break;
            case 1: // Path GREY
                Board.GameBoard[x,y] = 2;
                rendererObj.material.color = Color.white;
                break;
            case 2: // Build Spot WHITE
                Board.GameBoard[x,y] = 3;
                rendererObj.material.color = Color.red;
                break;
            case 3: // EnemyBase RED
                Board.GameBoard[x,y] = 4;
                rendererObj.material.color = Color.green;
                break;
            case 4: // PlayerBase GREEN
                Board.GameBoard[x,y] = 0;
                rendererObj.material.color = Color.black;
                break;
            default:
                Board.GameBoard[x,y] = 0;
                rendererObj.material.color = Color.black;
                break;
        }
        Debug.Log(Board.GameBoard[x,y] + $" {x},{y}");
    }

    public void SetCoordinates(int x, int y){
        this.x = x;
        this.y = y;
        SetColor();
    }

    private void SetColor()
    {
        switch(Board.GameBoard[x,y]){
            case 0: // Empty BLACK
                rendererObj.material.color = Color.black;
                break;
            case 1: // Path GREY
                rendererObj.material.color = Color.grey;
                break;
            case 2: // Build Spot WHITE
                rendererObj.material.color = Color.white;
                break;
            case 3: // EnemyBase RED
                rendererObj.material.color = Color.red;
                break;
            case 4: // PlayerBase GREEN
                rendererObj.material.color = Color.green;
                break;
            default:
                rendererObj.material.color = Color.black;
                break;
        }
    }

}
