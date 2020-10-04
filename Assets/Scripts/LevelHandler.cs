using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Levels
{
    public class LevelHandler : MonoBehaviour
    {
        private LevelsController _levelsController;
        [SerializeField] private Transform _cellsContainer;
        private CellsController _cellsController;

        public CellsController CellsController => _cellsController;


        public void StartLevel(LevelsController controller)
        {
            _levelsController = controller;
            _cellsController = new CellsController();
            CacheCells();
        }

        public void EndLevel()
        {
            _levelsController.NextLevel();
        }

        private void CacheCells()
        {
            foreach (Transform cellChild in _cellsContainer)
            {
                CellBase cell = cellChild.gameObject.GetComponent<CellBase>();
                cell.Coordinate = Utils.Utils.GetCoordinate(cellChild.position);
                _cellsController.AddCell(cell);
                cell.LevelHandler = this;
            }
        }
    }
}