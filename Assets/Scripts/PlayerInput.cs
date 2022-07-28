using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Minefield minefield;
    bool isActive = true;

    private void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            InteractWithCell();
        }
    }

    private void InteractWithCell()
    {
        RaycastHit2D hit = Utils.GetRaycastHit2DFromMousePosition();
        if (!hit) return;
        Vector3Int cellCoords = new Vector3Int((int)hit.transform.position.x, (int)hit.transform.position.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            minefield.OpenCellByCoords(cellCoords);
        }
        else
        {
            minefield.SetBombFlag(cellCoords);
        }
    }
}
