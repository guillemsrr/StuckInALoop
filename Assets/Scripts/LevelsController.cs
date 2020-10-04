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
        [SerializeField] private LevelHandler[] _levels;
        private int CurrentLevel = -1;


        private void Start()
        {
            NextLevel();
        }

        public void NextLevel()
        {
            CurrentLevel++;
            _levels[CurrentLevel].StartLevel(this);

            _playerController.CellsController = _levels[CurrentLevel].CellsController;
            _clonesController.CellsController = _levels[CurrentLevel].CellsController;
        }
    }
}