using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSprites : MonoBehaviour
{
    //Rule tiles
    [Header("Rule tiles")]
    public RuleTile TILE_GROUND;
    public RuleTile TILE_MOUNTAIN;
    public RuleTile TILE_ROAD;
    public RuleTile TILE_FIELD;

    //Tiles
    [Header("Tiles land")]
    public Tile TILE_WATER; 
    public Tile TILE_FOREST;

    [Header("Tiles structures")]
    public Tile TILE_TOWN;
}
