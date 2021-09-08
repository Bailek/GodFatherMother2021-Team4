using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool loopWave = false;

    private void Start()
    {
        StartWave();

        // Listeners
    }

    private void StartWave()
    {

    }
    //private IEnumerator Start()
    //{
    //    do
    //    {
    //        yield return StartCoroutine(SpawnAllWaves());
    //    } while (loopWave);

    //}

    private IEnumerator SpawnAllWaves()
    {
        yield return null;
        //for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        //{
        //    var currentWave = waveConfigs[waveIndex];
        //    yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        //}
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        yield return null;
        //for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        //{
        //    var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

        //    // get configuration of the wave to pass on enemypathing
        //    newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
        //    yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        //}
    }
}
