using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public abstract class CellBase : MonoBehaviour, ICell
    {
        protected bool _blocking;
        protected bool _actioned;

        public CellBase()
        {
            _blocking = false;
        }

        public Vector3Int Coordinate { get; set; }

        public bool IsBlocking => _blocking;

        public CellsController CellsController { set { } }
        public CharacterBase ContainedCharacter { get; set; }


        public virtual void Action()
        {
            ContainedCharacter = null;
        }
    }
}