using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StuckInALoop.Utils;

namespace StuckInALoop.Player
{
    public class PlayerController : CharacterBase
    {
        [SerializeField] private CellsController _cellsController;
        [SerializeField] private ClonesController _clonesController;


        private void Awake()
        {
        }

        private void Start()
        {
            _playerMovement = new PlayerMovement(this, transform);
            CurrentCoordinate = Vector3Int.zero;
            Movements.Add(transform.localPosition);
        }

        private void Update()
        {
            _playerMovement.DetectPlayerMovementInput();
        }

        public override void TryMovement(Vector3Int coord)
        {
            if (!_cellsController.CanMove(CurrentCoordinate + coord)) return;

            CurrentCoordinate += coord;
            _playerMovement.MoveToPosition(CurrentCoordinate, MovementFinished);
            Movements.Add(CurrentCoordinate);
            _clonesController.NextStep();
        }

        public override void MovementFinished()
        {
            //_clonesController.DetectPlayerConflict(this);
            _clonesController.CellCloneActions();
            _cellsController.CellAction(this);
            _cellsController.CellsActions();
        }

        public override void Clone(StartCell startCell)
        {
            CurrentCoordinate = startCell.Coordinate;
            _playerMovement.MoveToPosition(CurrentCoordinate);
            _clonesController.AddClone(this);
            Reset();
        }

        public override void Die()
        {
            _playerMovement.MoveToPosition(Movements[0], Reset);
        }

        private void Reset()
        {
            CurrentCoordinate = Utils.Utils.GetCoordinate(Movements[0]);
            Movements.Clear();
            Movements.Add(CurrentCoordinate);
        }
    }
}