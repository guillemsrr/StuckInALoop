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
        private int _numberMovements;
        public void Initialize(Vector3[] movements)
        {
            _movements = movements;
            _characterMovement = new CharacterMovement(this, transform, MOVE_SPEED);
            NextMovement();
            _numberMovements = movements.Length - 1;
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

        public IEnumerator DieAfter()
        {
            yield return new WaitForSeconds(0.5f);
            Die();
        }

        public override void Clone()
        {
            if(_currentMovementStep == _numberMovements)
                _cloned = true;
        }

        public override void Teleport(Vector3Int cellCoordinate)
        {
            CurrentCoordinate = cellCoordinate;
            _characterMovement.MoveToPosition(CurrentCoordinate);
        }
    }
}