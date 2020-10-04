using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StuckInALoop.Utils;

namespace StuckInALoop.Player
{
    public class PlayerController : CharacterBase
    {
        private const float MOVE_SPEED = 10f;

        [SerializeField] private ClonesController _clonesController;
        
        public CellsController CellsController { get;  set; }


        private void Start()
        {
            _characterMovement = new CharacterMovement(this, transform, MOVE_SPEED);
            CurrentCoordinate = Vector3Int.zero;
            Movements.Add(transform.position);
        }

        private void Update()
        {
            _characterMovement.DetectPlayerMovementInput();
        }

        public override void TryMovement(Vector3Int coord)
        {
            if (!CellsController.CanMove(CurrentCoordinate + coord)) return;

            _clonesController.NextStep();
            CurrentCoordinate += coord;
            _characterMovement.MoveToPosition(CurrentCoordinate, MovementFinished);
            Movements.Add(CurrentCoordinate);
        }

        public override void MovementFinished()
        {
            if (!_clonesController.DetectPlayerConflict(this))
            {
                CellsController.CellAction(this);
                _clonesController.CellCloneActions();
            }
            CellsController.CellsActions();
        }

        public override void Clone()
        {
            _clonesController.AddClone(this);
        }

        public override void Teleport(Vector3Int cellCoordinate)
        {
            CurrentCoordinate = cellCoordinate;
            _characterMovement.Reset();
            _characterMovement.MoveToPosition(CurrentCoordinate, Reset);
        }

        public override void Die()
        {
            CurrentCoordinate = Utils.Utils.GetCoordinate(Movements[0]);
            _characterMovement.MoveToPosition(Movements[0], Reset);
        }

        public override void Reset()
        {
            Movements.Clear();
            Movements.Add(CurrentCoordinate);
            _characterMovement.Reset();
        }
    }
}