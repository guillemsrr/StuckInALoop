using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class DoorCell : CellBase
    {
        private const string OPERATE_ANIMATION = "Operate";

        [SerializeField] private GameObject _laser;
        [SerializeField] private StartCell _startCell;
        [SerializeField] private Animator _animator;

        public DoorCell()
        {
        }

        public override void Activate(bool open)
        {
            base.Activate(!open);
            _laser.SetActive(!open);
        }

        public override void Action( )
        {
            if (ContainedCharacter && _isActive)
            {
                _animator.SetTrigger(OPERATE_ANIMATION);
                ContainedCharacter.Teleport(_startCell.Coordinate);
            }

            base.Action();
        }
    }
}