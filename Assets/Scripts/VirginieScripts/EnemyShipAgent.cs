using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAgent : EnemyAgent
{
    [Header("       SOUND")]
    public string firingSoundName;

    [Header("       BULLET")]
    public GameObject bulletPrefab;

    [Header ("      DEBUG")]
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

    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        if (shipManager == null || ship == null) return;
        if (!hasArriveOnTarget)
        {
            MoveToTarget();
            VerifyHasArriveToTarget();
        }
    }
    public void FixedUpdate()
    {
        if (!canShoot) return;
        Shoot();
    }
    public void RotateTowardTarget()
    {
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToTarget = target - forward;
        Vector3 dirToShip = vForwardToTarget.normalized;
        float angle = Mathf.Atan2(dirToShip.y, dirToShip.x) * Mathf.Rad2Deg - 90f;
        transform.Rotate(new Vector3(0, 0, angle), Space.World);
    }

    public void RotateTowardShip()
    {
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToShip = ship.transform.position - forward;
        Vector3 dirToShip = vForwardToShip.normalized;
        float angle = Mathf.Atan2(dirToShip.y, dirToShip.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 100);

        if (Quaternion.Angle(transform.rotation, q) <= 5)
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        timer += Time.fixedDeltaTime;
        float delayBetweenFire = 1.0f / (fireRate * fireRateMultiplier);
        if (timer >= delayBetweenFire)
        {
            GameObject newBullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, 0));
            timer -= delayBetweenFire;

            SoundManager.Instance.PlaySound(firingSoundName);
        }
    }

    public void VerifyHasArriveToTarget()
    {
        float distance2Target = Vector2.Distance((Vector2)transform.position, target);
        if (distance2Target <= 0.05f)
        {
            hasArriveOnTarget = true;
            transform.position = target;
            target = ship.transform.position;
            canShoot = true;
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
