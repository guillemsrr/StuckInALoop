using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _worldContainer;
    private const float EPSILON = 0.01f;
    private const float MOVE_SPEED = 6f;

    private void Update()
    {
        
    }

    public void CameraTranslation(Vector3 position)
    {
        StartCoroutine(LerpToPosition(position));
    }

    private IEnumerator LerpToPosition(Vector3 position)
    {
        while (Vector3.Distance(transform.position, position) > EPSILON)
        {
            transform.position = Vector3.Lerp(transform.position, position, MOVE_SPEED * Time.deltaTime);
            yield return null;
        }
    }
}
