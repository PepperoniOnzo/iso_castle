using System.Collections.Generic;
using UnityEngine;

public class ResultPath
{
    public List<Vector2Int> path = new List<Vector2Int> { };
    public int estimateTime = 0;

    public void Add(Vector2Int pos) => path.Add(pos);
    public void Reverse() { path.Reverse(); }
}
