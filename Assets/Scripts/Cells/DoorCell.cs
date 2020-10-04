using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class DoorCell : CellBase
    {
        [SerializeField] private GameObject _laser;
        [SerializeField] private StartCell _startCell;


        private bool _isOpen;
        public DoorCell()
        {
            _isOpen = false;
        }

        public void Open(bool open)
        {
            _isOpen = open;
            _laser.SetActive(!open);
        }

        public override void Action( )
        {
            if (ContainedCharacter && !_isOpen)
            {
                ContainedCharacter.Teleport(_startCell);
            }

            base.Action();
        }
    }
}