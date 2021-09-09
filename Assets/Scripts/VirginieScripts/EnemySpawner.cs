using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyList> enemyList = new List<EnemyList>();
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public float timeBeforeStartWave = 3.0f,
                    timeBeforeSpawn = 1.0f;
    public float speedMultiplierIncremental = 0.5f;
    public float damageMultiplierIncremental = 0.5f;
    public float fireRateMultiplierIncremental = 0.5f;
    public int enemyNbToAddEachWave = 1;
    public float radiusAroundStopPoint = 2.0f;
    private float speedMultiplier = 1.0f,
                damageWeakMultiplier = 1.0f,
                fireRateWeakMultiplier = 1.0f,
                damageStrongMultiplier = 1.0f,
                fireRateStrongMultiplier = 1.0f;
    private int waveCount = 1;
    private bool hasSpawn = false;
    private List<SpawnPoint> asteroidSpawnPoint = new List<SpawnPoint>(),
                             weakSpawnPoint = new List<SpawnPoint>(),
                            strongSpawnPoint = new List<SpawnPoint>();

    [Header("   DEBUG")]
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isWaveFinished = false;
    private void Awake()
    {
        CreateListSpawnPointsByType();

        // EnemyManager
        WaveEvent.OnNoEnemy.AddListener(FinishWave);
    }
    private void CreateListSpawnPointsByType()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            foreach (SpawnType spawnType in spawnPoint.spawnTypes)
            {
                switch (spawnType)
                {
                    case SpawnType.ASTEROID: asteroidSpawnPoint.Add(spawnPoint); break;
                    case SpawnType.STRONG: strongSpawnPoint.Add(spawnPoint); break;
                    case SpawnType.WEAK: weakSpawnPoint.Add(spawnPoint); break;
                }
            }
        }
    }

    public void StartWave()
    {
        isWaveFinished = false;
        StartCoroutine(SpawnEnemy());   
    }

    public void FinishWave()
    {
        isWaveFinished = true;
        CreateWave();
    }
    private void CreateWave()
    {
        waveCount++;
        ResetEnemyCount();
        IncrementEnemyCount();
        IncrementMultiplier();
        timer = 0;
    }

    private IEnumerator SpawnEnemy()
    {
        while (timer < timeBeforeStartWave)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        while (!isWaveFinished)
        {
            hasSpawn = false;

            if (waveCount % 5 == 0)
            {
                SpawnThreeType();
            }
            else
            {
                SpawnTwoType();
            }

            yield return new WaitForSeconds(timeBeforeSpawn);
        }
    }

    private void SpawnThreeType()
    {
        int rnd = Random.Range(0, 100);
        if (rnd <= 33)
        {
            SpawnEnemyAtIndexOrBelow(2);
        }
        else if (rnd <= 66)
        {
            SpawnEnemyAtIndexOrBelow(1);
            if (!hasSpawn) { SpawnEnemyAtIndexOrOver(1); }
        }
        else if (rnd <= 100)
        {
            SpawnEnemyAtIndexOrOver(0);
        }
    }

    private void SpawnTwoType()
    {
        int rnd = Random.Range(0, 100);

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

    private void CreateEnemy(int index)
    {
        EnemyAgent agent = enemyList[index].enemyPrefab.GetComponent<EnemyAgent>();
        List<SpawnPoint> currentSpawnPoints = FindSpawnPoint(agent);
        int spawnPointIndex = Random.Range(0, currentSpawnPoints.Count);
        SpawnPoint spawnPoint = currentSpawnPoints[spawnPointIndex];
        GameObject newEnemy = Instantiate(enemyList[index].enemyPrefab, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
        EnemyAgent newAgent = newEnemy.GetComponent<EnemyAgent>();
        Vector3 target = FindTarget(newAgent, spawnPoint);
        newAgent.SetTarget(target);
        SetMultiplier(newAgent);

        enemyList[index].currentCount++;
        hasSpawn = true;

        // EnemyManager
        WaveEvent.OnAddEnemy?.Invoke(newAgent);
    }

    private void SetMultiplier(EnemyAgent newAgent)
    {
        if (newAgent.enemyType.name == "Asteroid")
        {
            newAgent.SetSpeed(speedMultiplier);
        }
        else if (newAgent.enemyType.name == "WeakEnemy")
        {
            newAgent.SetDamage(damageWeakMultiplier);
            newAgent.SetFireRate(fireRateWeakMultiplier);
        }
        else
        {
            newAgent.SetDamage(damageStrongMultiplier);
            newAgent.SetFireRate(fireRateStrongMultiplier);
        }
    }

    private List<SpawnPoint> FindSpawnPoint(EnemyAgent agent)
    {
        if (agent.enemyType.name == "Asteroid")
        {
            return asteroidSpawnPoint;
        }
        else if (agent.enemyType.name == "WeakEnemy")
        {
            return weakSpawnPoint;
        }
        else if (agent.enemyType.name == "StrongEnemy")
        {
            return strongSpawnPoint;
        }

        return null;
    }

    private Vector3 FindTarget(EnemyAgent agent, SpawnPoint spawnPoint)
    {
        if (agent.enemyType.name == "Asteroid")
        {
            if (ShipManager.Instance == null) return new Vector3(0,0,0);
            return ShipManager.Instance.transform.position;
        }
        else
        {
            float xCenter = spawnPoint.stopPoint.transform.position.x;
            float yCenter = spawnPoint.stopPoint.transform.position.y;
            Vector2 center = new Vector2(xCenter, yCenter);
            Vector2 randomPoint = center + Random.insideUnitCircle * radiusAroundStopPoint * 0.5f;
            Vector3 target = new Vector3(randomPoint.x, randomPoint.y, 0);

            return target;
        }
    }

    private void ResetEnemyCount()
    {
        foreach (EnemyList enemy in enemyList)
        {
            enemy.currentCount = 0;
        }
    }

    private void IncrementEnemyCount()
    {
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
    }

    private void IncrementMultiplier()
    {
        speedMultiplier += speedMultiplierIncremental;
        damageWeakMultiplier += damageMultiplierIncremental;
        fireRateWeakMultiplier += fireRateMultiplierIncremental;

        if(waveCount % 5 == 0)
        {
            damageStrongMultiplier += 0.5f;
            fireRateStrongMultiplier += 0.5f;
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
