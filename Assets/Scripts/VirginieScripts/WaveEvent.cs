using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class WaveEvent
{
    public static EnemyEvent OnAddEnemy = new EnemyEvent();
    public static EnemyEvent OnDestroyEnemy = new EnemyEvent();
    public static UnityEvent OnNoEnemy = new UnityEvent();
    public static UnityEvent OnBoostActivated = new UnityEvent();
}

public class EnemyEvent : UnityEvent<EnemyAgent> { }
