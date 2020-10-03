using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Utils
{
    public static class Utils
    {
        public static Vector3Int GetCoordinate(Vector3 position)
        {
            return new Vector3Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
        }
    }
}