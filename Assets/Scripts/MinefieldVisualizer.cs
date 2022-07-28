using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinefieldVisualizer : MonoBehaviour
{
    [SerializeField] GameObject closedCell;
    [SerializeField] Transform cellContainer;
    [SerializeField] DigitSprites[] digitSprites;
    [SerializeField] Sprite flagSprite;
    [SerializeField] Sprite closedSprite;
    

    public void VisuializeCellsOnStart(List<Cell> cells)
    {
        foreach (var cell in cells)
        {
            GameObject cellInstance = Instantiate(closedCell, new Vector3(cell.XCoord, cell.YCoord, 0), Quaternion.identity);
            cellInstance.transform.parent = cellContainer;
            cell.CellInstanse = cellInstance;
            
        }
    }

    public void OpenCell(Cell cell, int bombsAround)
    {
        cell.CellInstanse.GetComponent<SpriteRenderer>().sprite = GetBombsAroundSprite(bombsAround);
    }

    private Sprite GetBombsAroundSprite(int bombsAround)
    {
        foreach (var sprite in digitSprites)
        {
            if (sprite.numberOfBombs == bombsAround) return sprite.digitSprite;
        }
        return null;
    }

    public void SetBombFlag(Cell cell, SetBombFlagResult result)
    {
        if (result == SetBombFlagResult.Setted)
        {
            cell.CellInstanse.GetComponent<SpriteRenderer>().sprite = flagSprite;
        }
        else
        {
            cell.CellInstanse.GetComponent<SpriteRenderer>().sprite = closedSprite;
        }
    }

    public void Clear(List<Cell> cells)
    {
        foreach (var cell in cells)
        {
            Destroy(cell.CellInstanse);
        }
    }
}

[System.Serializable]
public class DigitSprites
{
    public int numberOfBombs;
    public Sprite digitSprite;
}



