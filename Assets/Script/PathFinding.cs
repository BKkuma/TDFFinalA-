using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PathFinding : MonoBehaviour
{
    public Transform seeker, target;

    GridLL grid;

    private void Awake()
    {
        grid = GetComponent<GridLL>(); 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            FindPath(seeker.position, target.position);
        }
    }
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet.RemoveFirst();           
            closedSet.Add(node);

            if (node == targetNode)
            {
                sw.Stop();
                print("Path found: " + sw.ElapsedMilliseconds + "ms");
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.Getneighbours(node))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))                   
                        openSet.Add(neighbour);
                    
                }
            }
        }
    }

    void RetracePath(Node startnode,Node endnode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endnode;

        while (currentNode != startnode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }
    int GetDistance(Node nodeA,Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14*dstY + 10* (dstX-dstY);
        return 14*dstX + 10 * (dstY-dstX);
    }
}
