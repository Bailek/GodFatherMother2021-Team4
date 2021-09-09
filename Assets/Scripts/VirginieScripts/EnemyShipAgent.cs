using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAgent : EnemyAgent
{
    [Header("  BULLET")]
    public GameObject bulletPrefab;

    [Header ("  DEBUG")]
    [SerializeField] private float fireRate = 0;
    [SerializeField] private float damageMultiplier = 1.0f;
    [SerializeField] private float fireRateMultiplier = 1.0f;
    [SerializeField] private bool hasArriveOnTarget = false;
    [SerializeField] private float timer = 0f;

    private EnemyBullet enemyBullet;
    private bool canShoot = false;

    public override void Awake()
    {
        base.Awake();
        enemyBullet = bulletPrefab.GetComponent<EnemyBullet>();
        fireRate = enemyType.GetFireRate();
        enemyBullet.damage = base.damage;
    }

    public override void Update()
    {
        if (shipManager == null || ship == null) return;
        if (!hasArriveOnTarget)
        {
            base.MoveToTarget();
            VerifyHasArriveToTarget();
            base.RotateTowardShip();
        }
        else
        {
            canShoot = true;
        }
    }

    public void FixedUpdate()
    {
        if (!canShoot) return;
        Shoot();
    }
    private void Shoot()
    {
        timer += Time.fixedDeltaTime;
        float delayBetweenFire = 1.0f / (fireRate * fireRateMultiplier);
        if (timer >= delayBetweenFire)
        {
            GameObject newBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, 0));
            timer -= delayBetweenFire;
        }
    }

    public void VerifyHasArriveToTarget()
    {
        float distance2Target = Vector2.Distance((Vector2)transform.position, target.position);
        if (distance2Target <= 0.5f)
        {
            hasArriveOnTarget = true;
            transform.position = target.position;
        }
    }
    public override void SetDamage(float _damageMultiplier)
    {
        damageMultiplier = _damageMultiplier;
        damage = enemyType.damage * damageMultiplier;
        damage = Mathf.Clamp(damage, 0, base.enemyType.maxDamage);
        enemyBullet.damage = damage;
    }

    public override void SetFireRate(float _fireRateMultiplier)
    {
        fireRateMultiplier = _fireRateMultiplier;
        fireRate = enemyType.GetFireRate() * fireRateMultiplier;
        fireRate = Mathf.Clamp(fireRate, 0, base.enemyType.GetMaxFireRate());
    }
}
