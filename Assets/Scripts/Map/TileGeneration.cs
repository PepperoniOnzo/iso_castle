using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGeneration : MonoBehaviour
{
    public GameObject mapTileManager;
    public TileSprites ts;
    MapTileManager mtm;
    public SearchParameters searchParameters;

    private float[,] noiseMap;

    private void Start()
    {
        mtm = mapTileManager.GetComponent<MapTileManager>();
    }

    public void Initialize(int size, bool falloff, int cityCount)
    {
        //Map tile manager
        mtm.mapSize = size;
        mtm.passingGrid = new int[size, size];
        mtm.mapTiles = new MapTile[size, size];
        mtm.fallofOn = falloff;
        mtm.cityInfo.SetSityCount(cityCount);

        //Additional
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
                    mtm.SetMapTile(x, y, TileSettings.TILE_OCEAN, 0f, false);
                    mtm.passingGrid[x, y] = 0;
                }
            }
        }

        searchParameters.SetGrid(mtm.passingGrid);
        return earthObject;
    }

    public GameObject GenerateTileLayer()
    {
        var earthObject = new GameObject(TileSettings.LAYER_TILES);
        var earthTm = earthObject.AddComponent<Tilemap>();
        var earthTr = earthObject.AddComponent<TilemapRenderer>();
        earthTm.tileAnchor = new Vector3(0.5f, 0.5f, 0);
        earthTr.sortingLayerName = "Main";

        //Land generatoion
        for (int x = 0; x < mtm.mapSize; x++)
        {
            for (int y = 0; y < mtm.mapSize; y++)
            {
                if (noiseMap[x, y] > TileSettings.LEWEL_MOUNTAIN && mtm.CheckAvalaibility(x, y)) 
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_MOUNTAIN);
                    mtm.SetMapTile(x, y, TileSettings.TILE_MOUNTAIN, 0, false);
                    mtm.passingGrid[x, y] = 0;
                    mtm.avalaibleGrids.Add(new Vector2Int(x, y));
                    continue;
                }

                if (noiseMap[x, y] > TileSettings.LEWEL_FIELD && noiseMap[x, y] < TileSettings.LEWEL_FOREST
                    && mtm.CheckAvalaibility(x, y))
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_FIELD);
                    mtm.SetMapTile(x, y, TileSettings.TILE_FIELD, TileSettings.SPEED_FIELD, true);
                    mtm.avalaibleGrids.Add(new Vector2Int(x, y));
                }
                else if (noiseMap[x, y] > TileSettings.LEWEL_FOREST && noiseMap[x, y] < TileSettings.LEWEL_MOUNTAIN
                    && mtm.CheckAvalaibility(x, y))
                {
                    earthTm.SetTile(new Vector3Int(x, y, 0), ts.TILE_FOREST);
                    mtm.SetMapTile(x, y, TileSettings.TILE_FOREST, TileSettings.SPEED_FOREST, true);
                    mtm.avalaibleGrids.Add(new Vector2Int(x, y));
                }
            }
        }

        //City and road generations
        if (mtm.cityInfo.cityCount != 0 && mtm.avalaibleGrids.Count != 0) 
        {
            int count = 1, attempts = 10 * mtm.cityInfo.cityCount, avalaibleGrids = mtm.avalaibleGrids.Count;
            mtm.cityInfo.cityPos.Add(mtm.avalaibleGrids[Random.Range(0, avalaibleGrids)]);
            Vector2Int startPos = mtm.cityInfo.cityPos[0], nextPos, oldPos;

            earthTm.SetTile(new Vector3Int(startPos.x, startPos.y, 0), ts.TILE_TOWN);
            mtm.SetMapTile(startPos.x, startPos.y, TileSettings.TILE_TOWN, TileSettings.SPEED_TOWN, true);
            mtm.avalaibleGrids.Remove(startPos);

            do
            {
                nextPos = mtm.avalaibleGrids[Random.Range(0, mtm.avalaibleGrids.Count)];
                searchParameters.ChangePath(nextPos, startPos);
                ResultPath resultPath = searchParameters.aStar();
                if (resultPath.path.Count != 0 )
                    //&& searchParameters.CheckRFST(nextPos, TileSettings.ANOTHER_TOWN_RADIUS, TileSettings.TILE_TOWN))
                {
                    earthTm.SetTile(new Vector3Int(nextPos.x, nextPos.y, 0), ts.TILE_TOWN);
                    mtm.SetMapTile(nextPos.x, nextPos.y, TileSettings.TILE_TOWN, TileSettings.SPEED_TOWN, true);
                    mtm.avalaibleGrids.Remove(nextPos);

                    //Check
                    mtm.cityInfo.cityPos.Add(nextPos);

                    while (true)
                    {
                        oldPos = startPos;
                        startPos = mtm.cityInfo.cityPos[Random.Range(0, mtm.cityInfo.cityPos.Count)];
                        if (oldPos != startPos)
                        {
                            break;
                        }
                    }

                    List<Vector2Int> path = resultPath.path;
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        if (mtm.mapTiles[path[i].x, path[i].y].tileId == TileSettings.TILE_ROAD)
                        {
                            break;
                        }

                        if (mtm.mapTiles[path[i].x, path[i].y].tileId != TileSettings.TILE_TOWN)
                        {
                            earthTm.SetTile(new Vector3Int(path[i].x, path[i].y, 0), ts.TILE_ROAD);
                            mtm.SetMapTile(path[i].x, path[i].y, TileSettings.TILE_ROAD, TileSettings.SPEED_ROAD, true);
                        }
                    }

                    count++;
                }
                else
                {
                    attempts--;
                    if (attempts % 10 == 0) 
                    {
                        count++;
                        startPos = mtm.avalaibleGrids[Random.Range(0, mtm.avalaibleGrids.Count)];
                        earthTm.SetTile(new Vector3Int(startPos.x, startPos.y, 0), ts.TILE_TOWN);
                        mtm.SetMapTile(startPos.x, startPos.y, TileSettings.TILE_TOWN, TileSettings.SPEED_TOWN, true);
                        mtm.avalaibleGrids.Remove(startPos);
                    }
                }
            } while (count < mtm.cityInfo.cityCount || attempts == 0);
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
