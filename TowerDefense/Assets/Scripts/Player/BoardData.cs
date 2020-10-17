using UnityEngine;

[System.Serializable]
public class BoardData
{
    [System.Serializable]
    public enum PaneType
    {
        Empty,
        Path,
        BuildingSpot,
        EnemyBase,
        PlayerBase
    }
        //case 0: Empty BLACK
        //case 1: Path GREY
        //case 2: Build Spot WHITE
        //case 3: EnemyBase RED
        //case 4: PlayerBase GREEN

    public PaneType[] BoardValues;

    public BoardData(int x)
    {
        BoardValues = new PaneType[x];
    }
}