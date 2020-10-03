using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class DoorCell : CellBase
    {
        [SerializeField] private GameObject _laser;
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
                    ContainedCharacter.Die();
            }

            base.Action();
        }
    }
}