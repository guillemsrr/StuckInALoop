using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class PlayerMovement
    {
        private const float EPSILON = 0.05f;
        private const float MOVE_SPEED = 10f;

        private readonly Vector3Int FRONT_COORD = new Vector3Int(0, 0, 1);
        private readonly Vector3Int BACK_COORD = new Vector3Int(0, 0, -1);

        private CharacterBase _controller;
        private Transform _transform;
        private bool _moving = false;
        private float _offset_Y;
        private Coroutine _movementCoroutine;

        public PlayerMovement(CharacterBase controller, Transform transform)
        {
            _controller = controller;
            _transform = transform;
            _offset_Y = _transform.localPosition.y;

            //controller.StartCoroutine(DetectMovement());
        }

        private IEnumerator DetectMovement()
        {
            if (!_moving) yield return null;

            DetectPlayerMovementInput();
        }

        public void DetectPlayerMovementInput()
        {
            if (_moving) return;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                TryMovement(Vector3Int.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                TryMovement(Vector3Int.right);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                TryMovement(FRONT_COORD);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                TryMovement(BACK_COORD);
            }
        }

        private void TryMovement(Vector3Int coord)
        {
            _controller.TryMovement(coord);
        }

        public void MoveToPosition(Vector3 position, Action finalAction = null)
        {
            if(_movementCoroutine != null)
            {
                _controller.StopCoroutine(_movementCoroutine);
            }
            _movementCoroutine = _controller.StartCoroutine(LerpToPosition(position, finalAction));
        }

        private IEnumerator LerpToPosition(Vector3 position, Action finalAction)
        {
            _moving = true;
            position = new Vector3(position.x, position.y + _offset_Y, position.z);
            while (Vector3.Distance(_transform.localPosition, position) > EPSILON)
            {
                _transform.localPosition = Vector3.Lerp(_transform.localPosition, position, MOVE_SPEED * Time.deltaTime);
                yield return null;
            }

            _transform.localPosition = position;
            _moving = false;
            finalAction?.Invoke();
        }
    }
}