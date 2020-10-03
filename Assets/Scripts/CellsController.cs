using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StuckInALoop.Utils;

namespace StuckInALoop.Cell
{
    public class CellsController : MonoBehaviour
    {
        [SerializeField] private Transform _cellsContainer;

        private Dictionary<Vector3Int, CellBase> _cells = new Dictionary<Vector3Int, CellBase>();

        private void Start()
        {
            CacheCells();
        }

        private void CacheCells()
        {
            foreach (Transform cellChild in _cellsContainer)
            {
                CellBase cell = cellChild.gameObject.GetComponent<CellBase>();
                _cells[Utils.Utils.GetCoordinate(cellChild.localPosition)] = cell;
                cell.CellsController = this;
            }
        }

        public bool CanMove(Vector3Int coord)
        {
            if (!_cells.ContainsKey(coord)) return false;

            return !_cells[coord].IsBlocking;
        }

        public void CellAction(CharacterBase character)
        {
            CellBase cell = _cells[character.CurrentCoordinate];
            cell.ContainedCharacter = character;
        }

        public void CellsActions()
        {
            foreach(CellBase cell in _cells.Values)
            {
                cell.Action();
            }
        }
    }
}