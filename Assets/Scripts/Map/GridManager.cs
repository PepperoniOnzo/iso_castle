using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid grid;
    public GameObject tileGenerator;
    TileGeneration tg;

    public int size;
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();

        tg = tileGenerator.GetComponent<TileGeneration>();
        tg.Initialize(size, true);

        tg.GenerateGroundLayer().transform.SetParent(grid.gameObject.transform);
        
        tg.GenerateTileLayer().transform.SetParent(grid.gameObject.transform);
    }
}
