using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid grid;
    public GameObject tileGenerator;
    TileGeneration tg;

    public bool fallofOn = true;
    public int sizeGrid = 32, cityCount = 2;
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();

        tg = tileGenerator.GetComponent<TileGeneration>();
        tg.Initialize(sizeGrid, fallofOn, cityCount);

        tg.GenerateGroundLayer().transform.SetParent(grid.gameObject.transform);
        
        tg.GenerateTileLayer().transform.SetParent(grid.gameObject.transform);
    }
}
