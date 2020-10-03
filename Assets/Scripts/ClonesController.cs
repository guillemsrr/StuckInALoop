using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class ClonesController: MonoBehaviour
    {
        [SerializeField] private CellsController _cellsController;
        [SerializeField] private GameObject _cloneModel;
        [SerializeField] private Transform _clonesContainer;
        
        private List<CloneHandler> _clones = new List<CloneHandler>();

        public void AddClone(CharacterBase player)
        {
            GameObject cloneObject = Instantiate(_cloneModel, player.CurrentCoordinate, Quaternion.identity, _clonesContainer);
            CloneHandler clone = cloneObject.GetComponent<CloneHandler>();
            clone.Initialize(_cellsController, player.Movements.ToArray());
            _clones.Add(clone);
        }

        public void NextStep()
        {
            foreach(CloneHandler clone in _clones)
            {
                clone.NextMovement();
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
                _cellsController.CellAction(clone);
            }
        }
    }
}