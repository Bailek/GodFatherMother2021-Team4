using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyList> enemyList = new List<EnemyList>();
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public float timeBeforeStartWave = 3.0f;
    public float timeBeforeSpawn = 1.0f;
    public int enemyNbToAddEachWave = 1;
    public int waveCount = 0;
    public bool isWaveFinished = false;

    private bool hasSpawn = false;
    private List<SpawnPoint> asteroidSpawnPoint = new List<SpawnPoint>();
    private List<SpawnPoint> weakSpawnPoint = new List<SpawnPoint>();
    private List<SpawnPoint> strongSpawnPoint = new List<SpawnPoint>();

    [SerializeField] float timer = 0f;

    private void Awake()
    {
        foreach(SpawnPoint spawnPoint in spawnPoints)
        {
            foreach(SpawnType spawnType in spawnPoint.spawnTypes)
            {
                switch (spawnType)
                {
                    case SpawnType.ASTEROID: asteroidSpawnPoint.Add(spawnPoint); break;
                    case SpawnType.STRONG: strongSpawnPoint.Add(spawnPoint);  break;
                    case SpawnType.WEAK: weakSpawnPoint.Add(spawnPoint);  break;
                }
            }
        }
    }
    public void Start()
    {
        StartWave();
    }
    private void Update()
    {
        // TEST
        if (isWaveFinished)
        {
            CreateWave();
        }
    }
    public void StartWave()
    {
        waveCount++;
        StartCoroutine(SpawnEnemy());   
    }

    private IEnumerator SpawnEnemy()
    {
        while (!isWaveFinished)
        {
            hasSpawn = false;

            int rnd = Random.Range(0, 100);

            if (waveCount % 5 == 0)
            {
                if (rnd <= 33)
                {
                    SpawnEnemyAtIndexOrBelow(2);
                }
                else if (rnd <= 66)
                {
                    SpawnEnemyAtIndexOrBelow(1);
                    if(!hasSpawn) { SpawnEnemyAtIndexOrOver(1); }
                }
                else if (rnd <= 100)
                {
                    SpawnEnemyAtIndexOrOver(0);
                }
            }
            else
            {
                if (rnd <= 50)
                {
                    SpawnEnemyAtIndexOrBelow(1);
                    if (!hasSpawn) { SpawnEnemyAtIndexOrOver(1); }
                }
                else if (rnd <= 100)
                {
                    SpawnEnemyAtIndexOrOver(0);
                }
            }

            if (!hasSpawn)
            {
                isWaveFinished = true;
            }
            yield return new WaitForSeconds(timeBeforeSpawn);
        }

    }

    private void SpawnEnemyAtIndexOrBelow(int index)
    {
        if (index < 0) { return; }

        if (enemyList[index].currentCount < enemyList[index].maxCount)
        {
            CreateEnemy(index);
        }
        else
        {
            SpawnEnemyAtIndexOrBelow(index - 1);
        }
    }

    private void SpawnEnemyAtIndexOrOver(int index)
    {
        if (index > enemyList.Count - 1) { return; }

        if (enemyList[index].currentCount < enemyList[index].maxCount)
        {
            CreateEnemy(index);
        }
        else
        {
            SpawnEnemyAtIndexOrOver(index + 1);
        }
    }

    public void CreateEnemy(int index)
    {
        List<SpawnPoint> currentSpawnPoints = FindSpawnPoint(index);
        int spawnPointIndex = Random.Range(0, currentSpawnPoints.Count);
        GameObject enemy = Instantiate(enemyList[index].enemyPrefab, currentSpawnPoints[spawnPointIndex].transform.position, Quaternion.Euler(0, 0, 0));
        enemyList[index].currentCount++;
        hasSpawn = true;
    }

    public List<SpawnPoint> FindSpawnPoint(int index)
    {
        if (enemyList[index].enemyPrefab.GetComponent<EnemyAgent>().type.name == "Asteroid")
        {
            return asteroidSpawnPoint;
        }
        else if (enemyList[index].enemyPrefab.GetComponent<EnemyAgent>().type.name == "WeakEnemy")
        {
            return weakSpawnPoint;
        }
        else if (enemyList[index].enemyPrefab.GetComponent<EnemyAgent>().type.name == "StrongEnemy")
        {
            return strongSpawnPoint;
        }

        return asteroidSpawnPoint;
    }
    public void CreateWave()
    {
        waveCount++;
        ResetEnemyCount();

        //Increment Enemy
        int rnd = Random.Range(0, 50);
        if (rnd < 25)
        {
            enemyList[0].maxCount++;
        }
        else if (rnd < 50)
        {
            enemyList[1].maxCount++;
        }

        if (waveCount % 5 == 0)
        {
            enemyList[2].maxCount++;
        }
        isWaveFinished = false;
    }

    public void ResetEnemyCount()
    {
        foreach (EnemyList enemy in enemyList)
        {
            enemy.currentCount = 0;
        }
    }
}

[System.Serializable]
public class EnemyList
{
    public GameObject enemyPrefab;
    public int maxCount;
    public int currentCount;
}
