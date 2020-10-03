using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICell
{
    bool IsBlocking { get; }
    Vector3 Position { get; }
}
