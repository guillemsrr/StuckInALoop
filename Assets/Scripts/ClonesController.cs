using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class ClonesController: MonoBehaviour
    {
        [SerializeField] private GameObject _cloneModel;
        [SerializeField] private Transform _clonesContainer;
        
        private List<CloneHandler> _clones = new List<CloneHandler>();

        public CellsController CellsController { get; set; }


        public void AddClone(CharacterBase player)
        {
            GameObject cloneObject = Instantiate(_cloneModel, player.CurrentCoordinate, Quaternion.identity, _clonesContainer);
            CloneHandler clone = cloneObject.GetComponent<CloneHandler>();
            clone.Initialize(player.Movements.ToArray());
            _clones.Add(clone);
        }

        public void NextStep()
        {
            ClonesMovement();
            ClonesConflict();
        }

        private void ClonesMovement()
        {
            foreach (CloneHandler clone in _clones)
            {
                clone.NextMovement();
            }
        }

        private void ClonesConflict()
        {
            Queue<CloneHandler> _clonesToDestroy = new Queue<CloneHandler>();
            foreach (CloneHandler clone in _clones)
            {
                foreach (CloneHandler otherClone in _clones)
                {
                    if (clone == otherClone) continue;

                    if(clone.CurrentCoordinate == otherClone.CurrentCoordinate)
                    {
                        if (!_clonesToDestroy.Contains(clone))
                        {
                            _clonesToDestroy.Enqueue(clone);
                        }
                        if (!_clonesToDestroy.Contains(otherClone))
                        {
                            _clonesToDestroy.Enqueue(clone);
                        }
                    }
                }
            }

            foreach(CloneHandler clone in _clonesToDestroy)
            {
                StartCoroutine(clone.DieAfter());
                _clones.Remove(clone);
            }
        }

        public bool DetectPlayerConflict(CharacterBase player)
        {
            foreach (CloneHandler clone in _clones)
            {
                if(clone.CurrentCoordinate == player.CurrentCoordinate)
                {
                    clone.Die();
                    player.Die();
                    _clones.Remove(clone);
                    return true;
                }
            }

            return false;
        }

        public void CellCloneActions()
        {
            foreach (CloneHandler clone in _clones)
            {
                CellsController.CellAction(clone);
            }
        }
    }
}