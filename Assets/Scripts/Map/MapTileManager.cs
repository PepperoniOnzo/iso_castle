using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileManager : MonoBehaviour
{
    public MapTile[,] mapTiles { get; set; }
    public int[,] passingGrid { get; set; }
    public int mapSize { get; set; }
    public bool fallofOn { get; set; }

    public void SetMapTile(int x, int y, string tileId, float speed, bool penetrable)
    {
        mapTiles[x, y] = new MapTile(tileId, speed, penetrable);
    }

    public bool CheckAvalaibility(int x, int y)
    {
        bool avalaibility = true;

        if (x + 1 < this.mapSize)
        {
            if (mapTiles[x + 1, y].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (x - 1 >= 0)
        {
            if (mapTiles[x - 1, y].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (y + 1 < mapSize)
        {
            if (mapTiles[x, y + 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (y - 1 >= 0)
        {
            if (mapTiles[x, y - 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (x + 1 < mapSize && y + 1 < mapSize)
        {
            if (mapTiles[x + 1, y + 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (x + 1 < mapSize && y - 1 < mapSize)
        {
            if (mapTiles[x + 1, y - 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (x - 1 < mapSize && y + 1 < mapSize)
        {
            if (mapTiles[x - 1, y + 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        if (x - 1 < mapSize && y - 1 < mapSize)
        {
            if (mapTiles[x - 1, y - 1].tileId == TileSettings.TILE_OCEAN) return false;
        }

        return avalaibility;
    }
}
