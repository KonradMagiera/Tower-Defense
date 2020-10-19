using UnityEngine;

[System.Serializable]
public class BoardData
{
    public PaneType[] BoardValues;

    public BoardData(int x)
    {
        BoardValues = new PaneType[x];
    }

    public PaneType this[int key]
    {
        get => BoardValues[key];
        set => BoardValues[key] = value;
    }

    public int GetLength()
    {
        return BoardValues.Length;
    }

}