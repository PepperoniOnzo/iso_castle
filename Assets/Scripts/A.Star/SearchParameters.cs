using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class Node : IEquatable<Node>
{
    public Point position;
    public int g = 0, h = 0;
    public int f { get { return g + h; } }

    public Node previous;

    public Node(Point p) => position = p;

    public bool Equals(Node n)
    {
        return position.X == n.position.X && position.Y == n.position.Y;
    }
}

public class SearchParameters
{
    public Node startLocation { get; set; }
    public Node endLocation { get; set; }
    public int[,] grid { get; set; }
    public int size { get; set; }

    public List<Node> aStar()
    {
        List<Node> openList = new List<Node> { };
        List<Node> closedList = new List<Node> { };

        Node currentNode;

        openList.Add(startLocation);

        while (openList.Count > 0)
        {
            currentNode = openList.OrderBy(x => x.f).First();

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (currentNode.Equals(endLocation))
            {
                return GetFinishList(startLocation, currentNode);
            }

            foreach (Node node in GetNeighbourNodes(currentNode))
            {
                if (grid[node.position.X, node.position.Y] == 0 || closedList.Contains(node))
                {
                    continue;
                }

                node.g = GetMathDistance(startLocation, node);
                node.h = GetMathDistance(endLocation, node);

                node.previous = currentNode;

                if (!openList.Contains(node))
                {
                    openList.Add(node);
                }
            }
        }

        return new List<Node> { };
    }

    private List<Node> GetFinishList(Node startLocation, Node endLocation)
    {
        List<Node> finishedList = new List<Node> { };
        Node currentNode = endLocation;

        while (currentNode != startLocation)
        {
            finishedList.Add(currentNode);
            currentNode = currentNode.previous;
        }

        finishedList.Reverse();

        return finishedList;
    }

    private int GetMathDistance(Node start, Node node)
    {
        return Math.Abs(start.position.X - node.position.X) + Math.Abs(start.position.Y - node.position.Y);
    }

    private List<Node> GetNeighbourNodes(Node currentNode)
    {
        List<Node> neighbourNodes = new List<Node> { };
        int x = currentNode.position.X, y = currentNode.position.Y;

        if (x + 1 < size)
        {
            neighbourNodes.Add(new Node(new Point(x + 1, y)));
        }

        if (x - 1 >= 0)
        {
            neighbourNodes.Add(new Node(new Point(x - 1, y)));
        }

        if (y + 1 < size)
        {
            neighbourNodes.Add(new Node(new Point(x, y + 1)));
        }

        if (y - 1 >= 0)
        {
            neighbourNodes.Add(new Node(new Point(x, y - 1)));
        }

        return neighbourNodes;
    }

    public bool checkAvalaibility(int x, int y)
    {
        bool avalaibility = true;

        if (x + 1 < size)
        {
            if (grid[x + 1, y] == 0) return false;
        }

        if (x - 1 >= 0)
        {
            if (grid[x - 1, y] == 0) return false;
        }

        if (y + 1 < size)
        {
            if (grid[x, y + 1] == 0) return false;
        }

        if (y - 1 >= 0)
        {
            if (grid[x, y - 1] == 0) return false;
        }

        if (x + 1 < size && y + 1 < size) 
        {
            if (grid[x + 1, y + 1] == 0) return false;
        }

        if (x + 1 < size && y - 1 < size)
        {
            if (grid[x + 1, y - 1] == 0) return false;
        }

        if (x - 1 < size && y + 1 < size)
        {
            if (grid[x - 1, y + 1] == 0) return false;
        }

        if (x - 1 < size && y - 1 < size)
        {
            if (grid[x - 1, y - 1] == 0) return false;
        }

        return avalaibility;
    }
}
