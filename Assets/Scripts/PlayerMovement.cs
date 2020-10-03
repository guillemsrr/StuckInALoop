using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly Vector2Int LEFT_COORD = new Vector2Int(-1, 0);
    private readonly Vector2Int RIGHT_COORD = new Vector2Int(1, 0);
    private readonly Vector2Int UP_COORD = new Vector2Int(0, 1);
    private readonly Vector2Int DOWN_COORD = new Vector2Int(0, -1);

    private const float EPSILON = 0.1f;
    private const float MOVE_SPEED = 5f;

    private PlayerController _controller;
    private Transform _transform;
    private bool _moving = false;

    public PlayerMovement(PlayerController controller, Transform transform)
    {
        _controller = controller;
    } 

    private void Update()
    {
        if (_moving) return;

        DetectPlayerMovementInput();
    }

    private void DetectPlayerMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMovement(LEFT_COORD);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMovement(RIGHT_COORD);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMovement(UP_COORD);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMovement(DOWN_COORD);
        }
    }

    private void TryMovement(Vector2Int coord)
    {
        _controller.TryMovement(coord);
    }

    public void MoveToPosition(Vector3 position, Action endAction = null)
    {
        _controller.StartCoroutine(LerpToPosition(position, endAction));
    }

    private IEnumerator LerpToPosition(Vector3 position, Action endAction)
    {
        _moving = true;
        while (Vector3.Distance(_transform.localPosition, position) > EPSILON)
        {
            _transform.localPosition = Vector3.Lerp(_transform.localPosition, position, MOVE_SPEED * Time.deltaTime);
            yield return null;
        }

        _transform.localPosition = position;
        _moving = false;
        endAction?.Invoke();
    }
}
