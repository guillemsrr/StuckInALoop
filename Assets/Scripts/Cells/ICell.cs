using StuckInALoop.Levels;
using StuckInALoop.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuckInALoop.Cell
{
    public interface ICell
    {
        Vector3Int Coordinate { get; set; }
        LevelHandler LevelHandler{ get;  set; }
        bool IsBlocking { get; }
        CharacterBase ContainedCharacter { get; set; }

        void Action();
    }
}