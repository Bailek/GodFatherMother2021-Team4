using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAgent : EnemyAgent
{
    [Header("  DEBUG")]
    [SerializeField] private float speedMultiplier = 1.0f;

    public override void SetSpeed(float _speedMultiplier)
    {
        speedMultiplier = _speedMultiplier;
        speed = new Vector2(enemyType.speed * speedMultiplier, enemyType.speed * speedMultiplier);
    }

    public override void Update()
    {
        base.Update();

    }
}
