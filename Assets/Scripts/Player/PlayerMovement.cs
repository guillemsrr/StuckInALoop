using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Player
{
    public class CharacterMovement
    {
        private const float EPSILON = 0.1f;

        private readonly Vector3Int FRONT_COORD = new Vector3Int(0, 0, 1);
        private readonly Vector3Int BACK_COORD = new Vector3Int(0, 0, -1);

        private CharacterBase _controller;
        private Transform _transform;
        private float _offset_Y;
        private Coroutine _movementCoroutine;
        private Vector3 _targetPosition;
        private Action _action;
        private float _moveSpeed;


        public CharacterMovement(CharacterBase controller, Transform transform, float moveSpeed)
        {
            _controller = controller;
            _transform = transform;
            _offset_Y = _transform.position.y;
            _moveSpeed = moveSpeed;
        }

        public void DetectPlayerMovementInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMovement(Vector3Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMovement(Vector3Int.right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMovement(FRONT_COORD);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMovement(BACK_COORD);
            }
        }

        private void TryMovement(Vector3Int coord)
        {
            if (_movementCoroutine != null)
            {
                _controller.StopCoroutine(_movementCoroutine);
                FinishMovement();
            }

            _controller.TryMovement(coord);
        }

        public void MoveToPosition(Vector3 position, Action finalAction = null)
        {
            _movementCoroutine = _controller.StartCoroutine(LerpToPosition(position, finalAction));
        }

        private IEnumerator LerpToPosition(Vector3 position, Action finalAction)
        {
            _action = finalAction;

            _targetPosition = new Vector3(position.x, position.y + _offset_Y, position.z);
            while (Vector3.Distance(_transform.position, _targetPosition) > EPSILON)
            {
                _transform.position = Vector3.Lerp(_transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
                yield return null;
            }

            FinishMovement();
        }

        private void FinishMovement()
        {
            _transform.position = _targetPosition;
            _action?.Invoke();
            _movementCoroutine = null;
        }

        public void Reset()
        {
            if(_movementCoroutine != null)
            {
                _controller.StopCoroutine(_movementCoroutine);
            }
            _action = null;
        }
    }
}