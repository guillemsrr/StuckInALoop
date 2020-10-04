using StuckInALoop.Player;
using StuckInALoop.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public class StartCell : CellBase
    {
        [SerializeField] private LevelStartEffect _levelStartEffect;
        [SerializeField] private bool _triggered = false;
        public StartCell()
        {
        }

        public override void Action()
        {
            if (!ContainedCharacter || _triggered) return;

            ContainedCharacter.Reset();
            LevelHandler.EndLevel();

            if(_levelStartEffect)
                _levelStartEffect.StartEffect();

            _triggered = true;

            base.Action();
        }

        public void Reparent(Transform parent)
        {
            transform.parent = parent;
        }
    }
}