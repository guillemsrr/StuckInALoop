using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class ButtonCell : CellBase
    {
        private const string CONNECTION_ANIMATOR = "Connection";

        [SerializeField] private CellBase[] _connectedCells;
        [SerializeField] private Animator _animator;

        public ButtonCell()
        {
        }

        public override void Action( )
        {
            if(!_isActive)
            {
                ActivateCells(false);
                base.Action();
                return;
            }

            if (!ContainedCharacter)
            {
                ActivateCells(false);
                return;
            }

            ContainedCharacter.Clone();
            ActivateCells(true);

            base.Action();
        }

        private void ActivateCells(bool activate)
        {
            _animator.SetBool(CONNECTION_ANIMATOR, activate);

            foreach (CellBase cell in _connectedCells)
            {
                cell.Activate(activate);
            }
        }
    }
}