using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public abstract class CharacterBase : MonoBehaviour
    {
        protected CharacterMovement _characterMovement;

        public Vector3Int CurrentCoordinate { get; protected set; }

        public List<Vector3> Movements { get; protected set; } = new List<Vector3>();

        public abstract void Die();

        public virtual void MovementFinished()
        {

        }

        public virtual void TryMovement(Vector3Int coord)
        {

        }

        public abstract void Clone();
        public abstract void Teleport(StartCell startCell);
    }
}