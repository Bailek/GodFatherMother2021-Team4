using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAgent : EnemyAgent
{
    [Header("   RANDOM")]
    public float randFactor = 4.0f;
    public float lifeTime = 5.0f;
    [Header("  DEBUG")]
    [SerializeField] private float speedMultiplier = 1.0f;
    [SerializeField] private float timer = 0f;

    public override void CalculateVelocity()
    {
        float rndX = Random.Range(-randFactor, randFactor);
        float rndY = Random.Range(-randFactor, randFactor);
        Vector2 vEnemyShip = target - transform.position;
        vEnemyShip += new Vector2(rndX, rndY);
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;
        saveVelocity = velocity;
    }
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
        Rotation();
        timer += Time.deltaTime;

        if(timer > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    public void Rotation()
    {
        transform.Rotate(0, 0, enemyType.rotationSpeed, Space.Self);
    }
}
