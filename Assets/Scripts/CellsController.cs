using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StuckInALoop.Utils;

namespace StuckInALoop.Cell
{
    public class CellsController
    {
        private Dictionary<Vector3Int, CellBase> _cells;

        public CellsController()
        {
            _cells = new Dictionary<Vector3Int, CellBase>();
        }

        public void AddCell(CellBase cell)
        {
            _cells[cell.Coordinate] = cell;
        }

        public bool CanMove(Vector3Int coord)
        {
            if (!_cells.ContainsKey(coord)) return false;

            return !_cells[coord].IsBlocking;
        }

        public void CellAction(CharacterBase character)
        {
            if (!_cells.ContainsKey(character.CurrentCoordinate)) return;

            CellBase cell = _cells[character.CurrentCoordinate];
            cell.ContainedCharacter = character;
        }

        public void CellsActions()
        {
            foreach (CellBase cell in _cells.Values)
            {
                cell.Action();
            }
        }

        public void FadeInAppearence()
        {
            foreach(CellBase cell in _cells.Values)
            {
                cell.FadeInAappearence();
            }
        }

        public void Exclude(CellBase cell)
        {
            _cells.Remove(cell.Coordinate);
        }

        public void Petrify()
        {
            foreach (CellBase cell in _cells.Values)
            {
                cell.Petrify();
            }
        }
    }
}