using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Utils
{
    public class Fader : MonoBehaviour
    {
        private const float FADE_SPEED = 1f;
        private const float EPSILON = 0.01f;    
        [SerializeField] private MeshRenderer[] _meshRenderers;

        public MeshRenderer[] MeshRenderers => _meshRenderers;


        public IEnumerator Fade(float targetAlpha)
        {
            Color color;
            float alpha;
            while (!DetectFadeDone(targetAlpha))
            {
                foreach (MeshRenderer meshRenderer in _meshRenderers)
                {
                    color = meshRenderer.material.color;
                    alpha = Mathf.Lerp(color.a, targetAlpha, FADE_SPEED * Time.deltaTime);
                    meshRenderer.material.color = new Color(color.r, color.g, color.b, alpha);
                }
                yield return null;
            }
        }

        private bool DetectFadeDone(float targetAlpha)
        {
            foreach (MeshRenderer meshRenderer in _meshRenderers)
            {
                if(Mathf.Abs(meshRenderer.material.color.a - targetAlpha) > EPSILON)
                {
                    return false;
                }

                Color color = meshRenderer.material.color;
                meshRenderer.material.color = new Color(color.r, color.g, color.b, targetAlpha);
            }

            return true;
        }
    }
}