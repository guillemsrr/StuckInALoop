using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class CloneHandler : CharacterBase
    {
        private const float MOVE_SPEED = 12f;


        private CellsController _cellsController;
        private int _currentMovementStep = -1;
        private Vector3[] _movements;

        public void Initialize(CellsController cellsController, Vector3[] movements)
        {
            _cellsController = cellsController;
            _movements = movements;
            _characterMovement = new CharacterMovement(this, transform, MOVE_SPEED);
            NextMovement();
        }

        public void NextMovement()
        {
            SetNextMovementStep();
            _characterMovement.MoveToPosition(_movements[_currentMovementStep]);
        }

        private void SetNextMovementStep()
        {
            _currentMovementStep++;
            if(_currentMovementStep > _movements.Length - 1)
            {
                _currentMovementStep = 0;
            }

            CurrentCoordinate = Utils.Utils.GetCoordinate(_movements[_currentMovementStep]);
        }

        public override void Die()
        {
            Destroy(gameObject);
        }

        public override void Clone()
        {
            NextMovement();
        }

        public override void Teleport(StartCell startCell)
        {
            CurrentCoordinate = startCell.Coordinate;
            _characterMovement.MoveToPosition(CurrentCoordinate);
        }
    }
}