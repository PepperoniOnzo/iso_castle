using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile
{
    public string tileId {get; set;}
    public float speed { get; set; }
    public bool passing { get; set; }

    public MapTile(string tileId, float speed, bool passing)
    {
        this.tileId = tileId;
        this.speed = speed;
        this.passing = passing;
    }
}
