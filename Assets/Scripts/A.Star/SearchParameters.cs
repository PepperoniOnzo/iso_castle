using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class SearchParameters : MonoBehaviour 
{
    private Node startLocation, endLocation;
    private int[,] grid;
    private int size;
    public MapTileManager mtm;

    public void ChangePath(Vector2Int start, Vector2Int end)
    {
        startLocation = new Node(start);
        endLocation = new Node(end);
    }
    public void SetGrid(int[,] grid) 
    { 
        this.grid = grid;
        size = grid.GetLength(1);
    }
    public ResultPath aStar()
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
                if (grid[node.position.x, node.position.y] == 0 || closedList.Contains(node))
                {
                    continue;
                }

                node.g = GetMathDistance(startLocation, node) + (int)mtm.mapTiles[node.position.x, node.position.y].speed;
                node.h = GetMathDistance(endLocation, node);

                node.previous = currentNode;

                if (!openList.Contains(node))
                {
                    openList.Add(node);
                }
            }
        }

        return new ResultPath();
    }
    private ResultPath GetFinishList(Node startLocation, Node endLocation)
    {
        ResultPath resultPath = new ResultPath();
        Node currentNode = endLocation;

        // !! Calculate time
        while (currentNode != startLocation)
        {
           resultPath.Add(currentNode.position);
            currentNode = currentNode.previous;
        }

        resultPath.Reverse();
        return resultPath;
    }

    private int GetMathDistance(Node start, Node node)
    {
        return Math.Abs(start.position.x - node.position.x) + Math.Abs(start.position.y - node.position.y);
    }

    private List<Node> GetNeighbourNodes(Node currentNode)
    {
        List<Node> neighbourNodes = new List<Node> { };
        int x = currentNode.position.x, y = currentNode.position.y;

        if (x + 1 < grid.GetLength(0))
        {
            neighbourNodes.Add(new Node(new Vector2Int(x + 1, y)));
        }

        if (x - 1 >= 0)
        {
            neighbourNodes.Add(new Node(new Vector2Int(x - 1, y)));
        }

        if (y + 1 < size)
        {
            neighbourNodes.Add(new Node(new Vector2Int(x, y + 1)));
        }

        if (y - 1 >= 0)
        {
            neighbourNodes.Add(new Node(new Vector2Int(x, y - 1)));
        }

        return neighbourNodes;
    }
}
