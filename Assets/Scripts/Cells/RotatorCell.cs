using StuckInALoop.Player;
using StuckInALoop.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class RotatorCell : CellBase
    {
        private bool _triggered = false;
        public RotatorCell()
        {
        }

        public override void Action()
        {
            if (!ContainedCharacter || _triggered) return;

            _triggered = true;

            base.Action();
        }

        public void Reparent(Transform parent)
        {
            transform.parent = parent;
        }
    }
}