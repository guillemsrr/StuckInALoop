using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Utils
{
    public class LevelStartEffect : MonoBehaviour
    {
        [SerializeField] private Fader _fader;

        public void StartEffect()
        {
            StartCoroutine(FadeEffect());
        }
        
        private IEnumerator FadeEffect()
        {
            yield return _fader.Fade(0.5f);
            yield return _fader.Fade(0f);

            Destroy(gameObject);
        }
    }
}