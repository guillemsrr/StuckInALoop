﻿using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class StartCell : CellBase
    {
        public StartCell()
        {
        }

        public override void Action()
        {
            if (!ContainedCharacter) return;

            ContainedCharacter.Teleport(this);
            base.Action();
        }
    }
}