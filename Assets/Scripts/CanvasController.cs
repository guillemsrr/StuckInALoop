using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace StuckInALoop.Canvas
{
    public class CanvasController : MonoBehaviour
    {
        private const string LEVEL = "Level ";
        private const float LEVEL_OUT_TIMER = 6f;

        [SerializeField] private GameObject _menuObject;
        [SerializeField] private GameObject _tutorialObject;
        [SerializeField] private GameObject _levelUpObject;
        [SerializeField] private TextMeshProUGUI _textLevelUp;

        private WaitForSeconds _levelOutWait = new WaitForSeconds(LEVEL_OUT_TIMER);
        private bool _isMenuOut = false;


        private void Update()
        {
            if (_isMenuOut) return;

            DetectPlayerMovementInput();
        }

        public void DetectPlayerMovementInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.UpArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow))
            {
                MenuTutorialOut();
            }
        }

        public void MenuTutorialOut()
        {
            _menuObject.SetActive(false);
            _tutorialObject.SetActive(false);
        }

        public void LevelUp(string number)
        {
            _levelUpObject.SetActive(true);
            _textLevelUp.text = LEVEL + number;
            StartCoroutine(LevelOut());
        }

        private IEnumerator LevelOut()
        {
            yield return _levelOutWait;
            _levelUpObject.SetActive(false);
        }

        public void GameCompleted()
        {
            _textLevelUp.text = "You've completed the game! Thanks for playing";
            StartCoroutine(RestartGame());
        }

        private IEnumerator RestartGame()
        {
            yield return _levelOutWait;
            SceneManager.LoadScene("StuckInALoop"); 
        }
    }
}