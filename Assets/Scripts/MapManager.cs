using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    //private Grid grid;
    //public TileBase tileOcean, tileField, tileForest;
    //public RuleTile tileGround, tileMountain;
    //public int size = 128;

    //public float scale = .2f, falloffScale = 2f;
    //public float waterLevel = .3f, mountainLevel = .7f, forestLevel = .5f, fieldLevel = .4f;

    //float[,] noiseMap;


    //public GameObject dataManager;
    //DataManagment data;



    //void Start()
    //{
    //    grid = gameObject.GetComponent<Grid>();
    //    data = dataManager.GetComponent<DataManagment>();

    //    //Creating Earth tilemap
    //    var earthObject = new GameObject("Earth");
    //    var earthTm = earthObject.AddComponent<Tilemap>();
    //    var earthTr = earthObject.AddComponent<TilemapRenderer>();
    //    earthTm.tileAnchor = new Vector3(0.5f, 0.5f, 0);
    //    earthObject.transform.SetParent(grid.gameObject.transform);
    //    earthTr.sortingLayerName = "Main";

    //    //Creating Tiles Tilemap
    //    var tilesObject = new GameObject("Tiles");
    //    var tilesTm = tilesObject.AddComponent<Tilemap>();
    //    var tilesTr = tilesObject.AddComponent<TilemapRenderer>();
    //    tilesTm.tileAnchor = new Vector3(0.5f, 0.5f, 0);
    //    tilesObject.transform.SetParent(grid.gameObject.transform);
    //    tilesTr.sortingLayerName = "Main";

    //    //Init data
    //    data.initializeSizeGrid(size);

    //    // Falloff map
    //    float[,] falloffMap = new float[size, size];
    //    for (int y = 0; y < size; y++)
    //    {
    //        for (int x = 0; x < size; x++)
    //        {
    //            float xv = x / (float)size * 2 - 1;
    //            float yv = y / (float)size * 2 - 1;
    //            float v = Mathf.Max(Mathf.Abs(xv), Mathf.Abs(yv));
    //            falloffMap[x, y] = Mathf.Pow(v, falloffScale) / (Mathf.Pow(v, falloffScale) 
    //                + Mathf.Pow(2.2f - 2.2f * v, falloffScale));
    //        }
    //    }

    //    //Noise map
    //    noiseMap = new float[size, size];
    //    (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
    //    for (int x = 0; x < size; x++)
    //    {
    //        for (int y = 0; y < size; y++)
    //        {
    //            float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
    //            noiseValue -= falloffMap[x, y];
    //            noiseMap[x, y] = noiseValue;

    //            if (noiseMap[x, y] > waterLevel && noiseMap[x, y] < mountainLevel)
    //            {
    //                earthTm.SetTile(new Vector3Int(x, y, 0), tileGround);
    //                data.setGridData(x, y, 1);
    //            }
    //            else if(noiseMap[x, y] > mountainLevel)
    //            {
    //                earthTm.SetTile(new Vector3Int(x, y, 0), tileGround);

    //                tilesTm.SetTile(new Vector3Int(x, y, 0), tileMountain);
    //                data.setGridData(x, y, -1);
    //            }
    //            else 
    //            {
    //                earthTm.SetTile(new Vector3Int(x, y, 0), tileOcean);
    //                data.setGridData(x, y, 0);
    //            }
    //        }
    //    }

    //    //Forest
    //    for (int y = 0; y < size; y++)
    //    {
    //        for (int x = 0; x < size; x++)
    //        {
    //            if (data.getNeighavalaibility(x,y) && noiseMap[x, y] > forestLevel && noiseMap[x, y] < mountainLevel)
    //            {
    //                tilesTm.SetTile(new Vector3Int(x, y, 0), tileForest);
    //            }
    //            else if (data.getNeighavalaibility(x, y) && noiseMap[x, y] > fieldLevel && noiseMap[x, y] < forestLevel)
    //            {
    //                tilesTm.SetTile(new Vector3Int(x, y, 0), tileField);
    //            }
    //        }
    //    }
    //}
}
