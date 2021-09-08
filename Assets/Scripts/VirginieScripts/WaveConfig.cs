using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveConfig", menuName = "AI/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    public List<EnemyConfig> enemyList = new List<EnemyConfig>();
    public float timeBeforeStartWave = 3.0f;
    public int enemyIncremental = 1;
    
    //public List<Transform> GetWaypoints()
    //{
    //    var waveWaypoints = new List<Transform>();

    //    foreach (Transform child in pathPrefab.transform)
    //    {
    //        waveWaypoints.Add(child);
    //    }
    //    return waveWaypoints;
    //}

    public float GetTimeBeforeStartWave() { return timeBeforeStartWave; }
    public int GetEnemyIncremental = 1;
}

[System.Serializable]
public class EnemyConfig
{
    public GameObject enemyPrefab;
    public int startNumber;
}
