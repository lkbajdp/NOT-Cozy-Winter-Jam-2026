using System.Collections.Generic;
using UnityEngine;

public class Pathfinder
{
    private GridManager _gridManager;

    public Pathfinder(GridManager gridManager)
    {
        _gridManager = gridManager;
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
    {
        if (start == target) return new List<Vector2Int>();

        Queue<Vector2Int> frontier = new Queue<Vector2Int>();
        frontier.Enqueue(start);

        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        cameFrom[start] = start;

        while (frontier.Count > 0)
        {
            Vector2Int current = frontier.Dequeue();

            if (current == target)
                break;

            foreach (Vector2Int neighbor in GetNeighbors(current))
            {
                if (!_gridManager.Data.IsInGrid(neighbor)) continue;

                Tile tile = _gridManager.Data.GetTile(neighbor);
                if (tile == null || !tile.IsWalkable) continue;

                if (!cameFrom.ContainsKey(neighbor))
                {
                    frontier.Enqueue(neighbor);
                    cameFrom[neighbor] = current;
                }
            }
        }

        if (!cameFrom.ContainsKey(target))
        {
            Debug.Log("ѕуть не найден");
            return new List<Vector2Int>();
        }

        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int step = target;

        while (step != start)
        {
            path.Add(step);
            step = cameFrom[step];
        }

        path.Reverse();
        return path;
    }

    private List<Vector2Int> GetNeighbors(Vector2Int cell)
    {
        return new List<Vector2Int>
        {
            cell + Vector2Int.up,
            cell + Vector2Int.down,
            cell + Vector2Int.left,
            cell + Vector2Int.right
        };
    }
}