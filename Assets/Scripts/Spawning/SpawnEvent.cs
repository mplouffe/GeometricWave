using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    SquareFighter
}

public enum SpawnDirection
{
    North,
    East,
    South,
    West
}

[Serializable]
public class SpawnEvent
{
    public SpawnType type;
    public SpawnDirection direction;
    public float spawnRotation;
    public Vector2 spawnOffset;
}
