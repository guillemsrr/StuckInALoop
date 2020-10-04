using StuckInALoop.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Levels
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private Transform _cellsContainer;
        [SerializeField] private StartCell _nextlevelCell;
        [SerializeField] private Vector3 _cameraPosition;

        private LevelsController _levelsController;
        private CellsController _cellsController;


        public CellsController CellsController => _cellsController;
        public StartCell StartCell => _nextlevelCell;
        public Vector3 CameraPosition => _cameraPosition;


        public void StartLevel(LevelsController controller)
        {
            gameObject.SetActive(true);
            _levelsController = controller;
            _cellsController = new CellsController();
            CacheCells();
            CellsController.FadeInAppearence();
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

        public void FinishLevel()
        {
            StartCoroutine(ExcludeEndFrame());
        }

        private IEnumerator ExcludeEndFrame()
        {
            yield return null;
            CellsController.Exclude(_nextlevelCell);
            CellsController.Petrify();
        }
    }
}