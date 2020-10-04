using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class ButtonCell : CellBase
    {
        [SerializeField] private DoorCell[] _doors;

        private bool IsPressed = false;
        public ButtonCell()
        {
        }

        public override void Action( )
        {
            if (!ContainedCharacter)
            {
                OpenDoors(false);
                IsPressed = false;
                return;
            }

            //if (IsPressed)
            //{
            //    IsPressed = false;
            //    return;
            //}
            //IsPressed = true;

            ContainedCharacter.Clone();
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