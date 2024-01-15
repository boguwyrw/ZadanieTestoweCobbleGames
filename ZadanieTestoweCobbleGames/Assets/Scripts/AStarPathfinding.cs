using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    private const int STRAIGHT_COST = 10;
    private const int DIAGONAL_COST = 14;

    [SerializeField] private GroundCreator groundCreator;

    private List<PathNode> openList = new List<PathNode>();
    private List<PathNode> closedList = new List<PathNode>();

    public PathNode StartNode { get; set; }
    public PathNode EndNode { get; set; }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < FindPath().Count; i++)
            {
                Debug.Log("F: " + FindPath()[i].FCost);
            }
        }
    }

    private List<PathNode> FindPath()
    {
        openList.Add(StartNode);

        for (int pn = 0; pn < groundCreator.WalkablePathNode.Count; pn++)
        {
            PathNode pN = groundCreator.WalkablePathNode[pn];
            pN.GCost = int.MaxValue;
            pN.CameFromNode = null;
        }

        StartNode.GCost = 0;
        StartNode.HCost = CalculateCost(StartNode, EndNode);

        while(openList.Count > 0)
        {
            PathNode currentPathNode = GetLowestFCostPathNode(openList);
            if (currentPathNode == EndNode)
            {
                return CalculatePath();
            }

            openList.Remove(currentPathNode);
            closedList.Add(currentPathNode);

            foreach (PathNode neighbour in GetNeighbours(currentPathNode))
            {
                if (closedList.Contains(neighbour)) continue;

                int tempGCost = currentPathNode.GCost + CalculateCost(currentPathNode, neighbour);

                if (tempGCost < neighbour.GCost)
                {
                    neighbour.CameFromNode = currentPathNode;
                    neighbour.GCost = tempGCost;
                    neighbour.HCost = CalculateCost(neighbour, EndNode);

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }

    private List<PathNode> GetNeighbours(PathNode currentPathNode)
    {
        List<PathNode> neighboursList = new List<PathNode>();

        if (currentPathNode.PositionX - 1 >= 0)
        {
            neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX - 1, currentPathNode.PositionZ));

            if (currentPathNode.PositionZ - 1 >= 0)
            {
                neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX - 1, currentPathNode.PositionZ - 1));
            }

            if (currentPathNode.PositionZ + 1 < groundCreator.GridZ)
            {
                neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX - 1, currentPathNode.PositionZ + 1));
            }
        }

        if (currentPathNode.PositionX + 1 < groundCreator.GridX)
        {
            neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX + 1, currentPathNode.PositionZ));

            if (currentPathNode.PositionZ - 1 >= 0)
            {
                neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX + 1, currentPathNode.PositionZ - 1));
            }

            if (currentPathNode.PositionZ + 1 < groundCreator.GridZ)
            {
                neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX + 1, currentPathNode.PositionZ + 1));
            }
        }

        if (currentPathNode.PositionZ - 1 >= 0)
        {
            neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX, currentPathNode.PositionZ - 1));
        }

        if (currentPathNode.PositionZ + 1 < groundCreator.GridZ)
        {
            neighboursList.Add(groundCreator.GetPathNode(currentPathNode.PositionX, currentPathNode.PositionZ + 1));
        }

        return neighboursList;
    }

    private List<PathNode> CalculatePath()
    {
        List<PathNode> path = new List<PathNode>();

        path.Add(EndNode);

        PathNode currentNode = EndNode;

        while(currentNode.CameFromNode != null)
        {
            path.Add(currentNode.CameFromNode);
            currentNode = currentNode.CameFromNode;
        }

        path.Reverse();

        return path;
    }

    private int CalculateCost(PathNode start, PathNode end)
    {
        int xDistance = Mathf.Abs(start.PositionX - end.PositionX);
        int zDistance = Mathf.Abs(start.PositionZ - end.PositionZ);
        int remaining = Mathf.Abs(xDistance - zDistance);

        return DIAGONAL_COST * Mathf.Min(xDistance, zDistance) + STRAIGHT_COST * remaining;
    }

    private PathNode GetLowestFCostPathNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCost = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].FCost < lowestFCost.FCost)
            {
                lowestFCost = pathNodeList[i];
            }
        }

        return lowestFCost;
    }

    public void GetCalculateCost()
    {
        int result = CalculateCost(StartNode, EndNode);
        Debug.Log(result);
    }
}
