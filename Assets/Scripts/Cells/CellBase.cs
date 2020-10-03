using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellBase : MonoBehaviour, ICell
{
    [SerializeField] private Transform _transform;

    protected Vector3 _position;
    protected bool _blocking;

    public CellBase()
    {
        _position = _transform.localPosition;
    }

    public bool IsBlocking => _blocking;

    public Vector3 Position => _position;
}
