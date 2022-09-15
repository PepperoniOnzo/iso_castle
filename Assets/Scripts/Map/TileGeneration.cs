using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGeneration : MonoBehaviour
{
    public GameObject mapTileManager;
    public TileSprites ts;
    MapTileManager mtm;

    private float[,] noiseMap;

    private void Start()
    {
        mtm = mapTileManager.GetComponent<MapTileManager>();
    }

    public void Initialize(int size, bool falloff)
    {
        mtm.mapSize = size;

        mtm.passingGrid = new int[size, size];
        mtm.mapTiles = new MapTile[size, size];

        mtm.fallofOn = falloff;
        noiseMap = GenerateNoiseMap();
    }

    public GameObject GenerateGroundLayer()
    {
        var earthObject = new GameObject(TileSettings.LAYER_GROUND);
        var earthTm = earthObject.AddComponent<Tilemap>();
        var earthTr = earthObject.AddComponent<TilemapRenderer>();
        earthTm.tileAnchor = new Vector3(0.5f, 0.5f, 0);
        earthTr.sortingLayerName = "Main";

        if (mtm.fallofOn) GenerateFallofMap();

        for (int x = 0; x < mtm.mapSize; x++)
        {
            for (int y = 0; y < mtm.mapSize; y++)
            {
                if (noiseMap[x, y] > TileSettings.LEWEL_WATER)
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_GROUND);
                    mtm.SetMapTile(x, y, TileSettings.TILE_GROUND, TileSettings.SPEED_GROUND, true);
                    mtm.passingGrid[x, y] = 1;
                }
                else
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_WATER);
                    mtm.SetMapTile(x, y, TileSettings.TILE_GROUND, 0f, false);
                    mtm.passingGrid[x, y] = 0;
                }
            }
        }

        return earthObject;
    }

    public GameObject GenerateTileLayer()
    {
        var earthObject = new GameObject(TileSettings.LAYER_TILES);
        var earthTm = earthObject.AddComponent<Tilemap>();
        var earthTr = earthObject.AddComponent<TilemapRenderer>();
        earthTm.tileAnchor = new Vector3(0.5f, 0.5f, 0);
        earthTr.sortingLayerName = "Main";

        for (int x = 0; x < mtm.mapSize; x++)
        {
            for (int y = 0; y < mtm.mapSize; y++)
            {
                if (noiseMap[x, y] > TileSettings.LEWEL_MOUNTAIN && mtm.CheckAvalaibility(x, y)) 
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_MOUNTAIN);
                    mtm.SetMapTile(x, y, TileSettings.TILE_MOUNTAIN, 0, false);
                    mtm.passingGrid[x, y] = 0;
                    continue;
                }
            }
        }

        return earthObject;
    }
    private float[,] GenerateFallofMap()
    {
        float[,] falloffMap = new float[mtm.mapSize, mtm.mapSize];
        for (int y = 0; y < mtm.mapSize; y++)
        {
            for (int x = 0; x < mtm.mapSize; x++)
            {
                float xv = x / (float)mtm.mapSize * 2 - 1;
                float yv = y / (float)mtm.mapSize * 2 - 1;
                float v = Mathf.Max(Mathf.Abs(xv), Mathf.Abs(yv));
                falloffMap[x, y] = Mathf.Pow(v, TileSettings.SCALE_FALLOFF) / (Mathf.Pow(v, TileSettings.SCALE_FALLOFF)
                    + Mathf.Pow(2.2f - 2.2f * v, TileSettings.SCALE_FALLOFF));

                noiseMap[x, y] -= falloffMap[x, y];
            }
        }
        return falloffMap;
    }
    private float[,] GenerateNoiseMap()
    {
        float[,] noiseMapG = new float[mtm.mapSize, mtm.mapSize];
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
        for (int x = 0; x < mtm.mapSize; x++)
        {
            for (int y = 0; y < mtm.mapSize; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x * TileSettings.SCALE_NOISE + xOffset,
                    y * TileSettings.SCALE_NOISE + yOffset);
                noiseMapG[x, y] = noiseValue;
            }
        }
        return noiseMapG;
    }
}
