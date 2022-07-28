using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    int xCoord;
    int yCoord;
    bool isBomb;
    bool isOpened = false;
    bool isFlagged = false;
    GameObject cellInstanse;

    public Cell(int xCoord, int yCoord)
    {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }

    public bool IsBomb { get => isBomb; set => isBomb = value; }
    public int XCoord { get => xCoord; }
    public int YCoord { get => yCoord; }
    public GameObject CellInstanse { get => cellInstanse; set => cellInstanse = value; }

    public OpenCellResult OpenCell()
    {
        if (isOpened || isFlagged) return OpenCellResult.None;

        if (isBomb) return OpenCellResult.Gameover;

        isOpened = true;
        return OpenCellResult.Opened;
    }

    public SetBombFlagResult SetBombFlag()
    {
        if (isOpened) return SetBombFlagResult.None;
        if (isFlagged)
        {
            isFlagged = false;
            return SetBombFlagResult.Unsetted;
        }

        isFlagged = true;
        return SetBombFlagResult.Setted;
    }

}

public enum OpenCellResult
{
    Gameover,
    Opened,
    None
}

public enum SetBombFlagResult
{
    Setted,
    Unsetted,
    None
}


