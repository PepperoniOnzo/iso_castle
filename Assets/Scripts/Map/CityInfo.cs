using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityInfo
{
    public int cityCount = 0;
    public List<Vector2Int> cityPos = new List<Vector2Int>() { };

    public void SetSityCount(int count)
    {
        if (count >= 0) 
        {
            cityCount = count;
        }
    }
}
