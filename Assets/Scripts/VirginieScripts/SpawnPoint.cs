using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<SpawnType> spawnTypes = new List<SpawnType>();
}

public enum SpawnType
{
    ASTEROID,
    WEAK,
    STRONG,
}
