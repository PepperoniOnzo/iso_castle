using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSprites : MonoBehaviour
{
    //Rule tiles
    [Header("Tile Ground")]
    public RuleTile TILE_GROUND;
    [Header("Tile Mountain")]
    public RuleTile TILE_MOUNTAIN;

    //Tiles
    [Header("Tile Water")]
    public Tile TILE_WATER; 
    [Header("Tile Field")]
    public Tile TILE_FIELD;
    [Header("Tile Forest")]
    public Tile TILE_FOREST;
}
