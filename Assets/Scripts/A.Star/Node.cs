using System;
using UnityEngine;

public class Node : IEquatable<Node>
{
    public Vector2Int position;
    public int g = 0, h = 0;
    public int f { get { return g + h; } }

    public Node previous;

    public Node(Vector2Int p) => position = p;

    public bool Equals(Node n)
    {
        return position.x == n.position.x && position.y == n.position.y;
    }
}