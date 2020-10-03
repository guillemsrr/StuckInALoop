using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsController : MonoBehaviour
{
    private Dictionary<Vector2Int, CellBase> _cells;

    public bool CanMove( Vector2Int coord)
    {
        return (!_cells[coord].IsBlocking);
    }

    public Vector3 Position(Vector2Int coord)
    {
        return _cells[coord].Position;
    }
}
