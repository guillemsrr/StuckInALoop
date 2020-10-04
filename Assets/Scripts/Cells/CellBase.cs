using StuckInALoop.Levels;
using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public abstract class CellBase : MonoBehaviour, ICell
    {
        protected bool _blocking;

        public CellBase()
        {
            _blocking = false;
        }

        public Vector3Int Coordinate { get; set; }

        public bool IsBlocking => _blocking;

        public LevelHandler LevelHandler { get; set; }
        public CharacterBase ContainedCharacter { get; set; }


        public virtual void Action()
        {
            ContainedCharacter = null;
        }
    }
}