using StuckInALoop.Cell;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class CloneHandler : CharacterBase
    {
        private const float MOVE_SPEED = 12f;

        private int _currentMovementStep = -1;
        private Vector3[] _movements;
        private bool _cloned = false;

        public void Initialize(CellsController cellsController, Vector3[] movements)
        {
            _movements = movements;
            _characterMovement = new CharacterMovement(this, transform, MOVE_SPEED);
            NextMovement();
        }

        public void NextMovement()
        {
            Action action = null;
            if(_cloned)
            {
                _cloned = false;
                action = NextMovement;
            }

            SetNextMovementStep();
            _characterMovement.MoveToPosition(_movements[_currentMovementStep], action);
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

        private IEnumerator DieAfter()
        {
            yield return new WaitForSeconds(0.5f);
        }

        public override void Clone()
        {
            _cloned = true;
        }

        public override void Teleport(Vector3Int cellCoordinate)
        {
            CurrentCoordinate = cellCoordinate;
            _characterMovement.MoveToPosition(CurrentCoordinate);
        }
    }
}