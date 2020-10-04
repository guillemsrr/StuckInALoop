using StuckInALoop.Levels;
using StuckInALoop.Player;
using StuckInALoop.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public abstract class CellBase : MonoBehaviour, ICell
    {
        [SerializeField] private Fader _fader;
        [SerializeField] protected MeshRenderer[] _petrifyElements;
        [SerializeField] private Material _petrifyMaterial;

        [SerializeField] protected bool _isActive = true;

        protected bool _blocking;

        public CellBase()
        {
            _blocking = false;
        }

        public Vector3Int Coordinate { get; set; }

        public bool IsBlocking => _blocking;

        public LevelHandler LevelHandler { get; set; }
        public CharacterBase ContainedCharacter { get; set; }


        public virtual void Action()
        {
            ContainedCharacter = null;
        }

        public void FadeInAappearence()
        {
            foreach (MeshRenderer meshRenderer in _fader.MeshRenderers)
            {
                Color color = meshRenderer.material.color;
                meshRenderer.material.color = new Color(color.r, color.g, color.b, 0f);
            }

            StartCoroutine(_fader.Fade(1f));
        }

        public virtual void Petrify()
        {
            foreach(MeshRenderer meshRenderer in _petrifyElements)
            {
                meshRenderer.material = _petrifyMaterial;
            }
        }

        public virtual void Activate(bool active)
        {
            _isActive = active;
        }
    }
}