using StuckInALoop.Player;
using StuckInALoop.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class TeleportCell : CellBase
    {
        [SerializeField] private TeleportCell _teleportCell;

        public TeleportCell()
        {
        }

        public override void Action()
        {
            if (!ContainedCharacter) return;

            if(_isActive)
                ContainedCharacter.Teleport(_teleportCell.Coordinate);

            base.Action();
        }

        public void Reparent(Transform parent)
        {
            transform.parent = parent;
        }
    }
}