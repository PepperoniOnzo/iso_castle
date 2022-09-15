using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigliteMovement : MonoBehaviour
{
    [SerializeField] private Grid grid;
    private Vector3Int previousMousePos = new Vector3Int();

    void Update()
    {
        Vector3Int mousePos = GetMousePos();

        if (!mousePos.Equals(previousMousePos))
        {
            var higglitePos = grid.CellToWorld(mousePos);
            gameObject.transform.position = new Vector3(higglitePos.x, higglitePos.y, 0);
            previousMousePos = mousePos;
        }
    }

    private Vector3Int GetMousePos()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
