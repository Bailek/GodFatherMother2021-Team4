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
        float newSpeed = enemyType.speed * speedMultiplier;
        newSpeed = Mathf.Clamp(newSpeed, 0, base.enemyType.maxSpeed);
        speed = new Vector2(newSpeed, newSpeed);
    }

    public override void Update()
    {
        base.Update();

    }
}
