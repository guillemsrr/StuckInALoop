using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class CloneHandler : CharacterBase
    {
        private CellsController _cellsController;
        private PlayerMovement _characterMovement;
        private int _currentMovementStep = 0;
        private Vector3[] _movements;

        public void Initialize(CellsController cellsController, Vector3[] movements)
        {
            _cellsController = cellsController;
            _movements = movements;
            _characterMovement = new PlayerMovement(this, transform);
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
            //Destroy(gameObject);
        }

        public override void Clone(StartCell startCell)
        {
            NextMovement();
        }
    }
}