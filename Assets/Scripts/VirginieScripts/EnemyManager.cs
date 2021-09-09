using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("   DEBUG")]
    [SerializeField] private List<EnemyAgent> enemyAgents = new List<EnemyAgent>();

    private void Awake()
    {
        // EnemySpawner
        WaveEvent.OnAddEnemy.AddListener(AddAgent);
        WaveEvent.OnDestroyEnemy.AddListener(RemoveAgent);
    }
    public void AddAgent(EnemyAgent newAgent)
    {
        enemyAgents.Add(newAgent);
    }

    public void RemoveAgent(EnemyAgent agent)
    {
        enemyAgents.Remove(agent);

        if(enemyAgents.Count <= 0)
        {
            WaveEvent.OnNoEnemy.Invoke();
        }
    }
}
