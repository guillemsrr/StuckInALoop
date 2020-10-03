using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CellsController _cellsController;

    private PlayerMovement _playerMovement;
    private Vector2Int _currentCoord;

    private void Awake()
    {
        _playerMovement = new PlayerMovement(this, transform);
    }

    private void Start()
    {
        
    }

    public void TryMovement(Vector2Int coord)
    {
        if(_cellsController.CanMove(_currentCoord + coord))
        {
            _playerMovement.MoveToPosition(_cellsController.Position(coord));
        }
    }
}
