using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class EndCell : CellBase
    {
        public EndCell()
        {
        }

        public override void Action()
        {
            if (!ContainedCharacter) return;

            LevelHandler.EndLevel();
            base.Action();
        }
    }
}