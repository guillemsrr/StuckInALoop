using StuckInALoop.Canvas;
using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Levels
{
    public class LevelsController : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private ClonesController _clonesController;
        [SerializeField] private CanvasController _canvasController;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private LevelHandler[] _levels;
        
        private int CurrentLevel = 0;


        private void Start()
        {
            _levels[CurrentLevel].StartLevel(this);
            _playerController.CellsController = _levels[CurrentLevel].CellsController;
            _clonesController.CellsController = _levels[CurrentLevel].CellsController;
        }

        public void NextLevel()
        {
            _levels[CurrentLevel].FinishLevel();

            if(CurrentLevel+1 == 5)
            {
                _canvasController.GameCompleted();
                    return;
            }
            _levels[CurrentLevel].StartCell.Reparent(_levels[CurrentLevel + 1].transform);
            _levels[CurrentLevel + 1].StartLevel(this);
            CurrentLevel++;

            _cameraController.CameraTranslation(_levels[CurrentLevel].CameraPosition);
            _playerController.CellsController = _levels[CurrentLevel].CellsController;
            _clonesController.CellsController = _levels[CurrentLevel].CellsController;
            _canvasController.LevelUp(CurrentLevel.ToString());
        }
    }
}