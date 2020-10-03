using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class ButtonCell : CellBase
    {
        [SerializeField] private DoorCell[] _doors;
        [SerializeField] private StartCell _startCell;
        public ButtonCell()
        {
        }
        public override void Action( )
        {
            if (!ContainedCharacter)
            {
                OpenDoors(false);
                return;
            }

            ContainedCharacter.Clone(_startCell);
            OpenDoors(true);

            base.Action();
        }

        private void OpenDoors(bool open)
        {
            foreach(DoorCell doorCell in _doors)
            {
                doorCell.Open(open);
            }
        }
    }
}