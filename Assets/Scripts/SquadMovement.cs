using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SquadMovement : MonoBehaviour
{
    //[SerializeField] private Grid grid;
    //private Vector3 finalSquadPos, currentSquadPosition = new Vector3(0, 10, 1);

    //bool isMoving = false;
    //List<Node> movingTraectory;
    //int moveCount, moveCountNow;
    //float moveTime = 1f, nextMove;

    //private Rigidbody2D rb;

    //public GameObject dataManager;
    //DataManagment data;

    //private Point start, end;

    //void Start()
    //{
    //    rb = gameObject.GetComponent<Rigidbody2D>();
    //    data = dataManager.GetComponent<DataManagment>();

    //    rb.MovePosition(new Vector2(currentSquadPosition.x, currentSquadPosition.y));

    //    Tilemap tilemap = grid.GetComponent<Tilemap>();
    //    tilemap.CompressBounds();
    //}


    //void Update()
    //{
    //    //Mouse position Cell Cords im Grid (1; 1)
    //    // grid.CellToWorld(mousePos) -> cell position in world (0.5; -0.25)
    //    Vector3Int mousePos = GetMousePos();



    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        finalSquadPos = grid.CellToWorld(mousePos);
    //        //rb.velocity = new Vector2(-0.5f, -0.25f);

    //        start = new Point(mousePos.x, mousePos.y);
    //    }

    //    if (Input.GetMouseButton(1))
    //    {
    //        end = new Point(mousePos.x, mousePos.y);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        movingTraectory = data.searchA(start.X, start.Y, end.X, end.Y);

    //        foreach (Node item in movingTraectory)
    //        {
    //            Debug.Log(item.position);
    //        }

    //        moveCount = movingTraectory.Count;
    //        isMoving = true;
    //        nextMove = Time.time + moveTime;
    //    }

    //    if (isMoving && Time.time > nextMove) 
    //    {
    //        Move();
    //    }
    //    //if (!rb.transform.position.Equals(finalSquadPos))
    //    //{
    //    //    Vector3Int final = Vector3Int.FloorToInt(finalSquadPos.normalized);


    //    //    Debug.Log("FINAL: " + final);
    //    //    //rb.velocity = new Vector3(final.x * speed, final.y * speed, 1);

    //    //    rb.MovePosition(new Vector2(final.x, final.y));
    //    //}
    //    //else
    //    //{
    //    //    rb.velocity = Vector3.zero;
    //    //}
    //}

    //private void Move()
    //{
    //    if (moveCountNow < moveCount)
    //    {
    //        Vector3 vc = grid.CellToWorld(new Vector3Int(movingTraectory[moveCountNow].position.X,
    //            movingTraectory[moveCountNow].position.Y, 1));

    //        rb.MovePosition(new Vector2(vc.x, vc.y));
    //        nextMove = Time.time + moveTime;
    //        moveCountNow++;
    //    }
    //    else
    //    {
    //        start = end;
    //        moveCountNow = 0;
    //        isMoving = false;
    //    }
    //}

    //private Vector3Int GetMousePos()
    //{
    //    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    return grid.WorldToCell(mouseWorldPos);
    //}
}
