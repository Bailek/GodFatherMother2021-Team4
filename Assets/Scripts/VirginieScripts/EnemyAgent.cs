using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAgent : MonoBehaviour
{
    public Enemy type;
    
    Rigidbody2D rb;
    HealthBar health;
    SpriteRenderer spriteRenderer;
    ShipManager shipManager;
    GameObject ship;
    Transform target;

    public float speedMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;
    public float fireRateMultiplier = 1.0f;
    public float damage = 0;
    public float fireRate = 0;
    bool hasArriveOnTarget = false;
    Vector2 speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health.SetMaxHealth(type.health);
        spriteRenderer.sprite = type.sprite;

        speed = new Vector2(type.speed, type.speed);
        damage = type.damage;
        if(type.name == "WeakEnemy" || type.name == "StrongEnemy")
        {
            fireRate = type.GetFireRate();
        }
    }
    private void Start()
    {
        shipManager = ShipManager.Instance;
        ship = shipManager.gameObject;
    }

    public void SetTarget(Transform value)
    {
        target = value;
    }

    private void FixedUpdate()
    {
        if (shipManager != null && !hasArriveOnTarget)
        {
            MoveToTarget();
            RotateTowardShip();
        }
    }
    private void MoveToTarget()
    {
        Vector2 vEnemyShip = target.position - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2.ClampMagnitude(speed, type.maxSpeed);
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;

        transform.position += (Vector3)velocity;
    }

    private void RotateTowardShip()
    {
        float angle = 0f;
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToTarget = ship.transform.position - forward;
        Vector3 dirForwardToTarget = vForwardToTarget.normalized;
        angle = Mathf.Atan2(dirForwardToTarget.y, dirForwardToTarget.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void SetSpeed(float _speedMultiplier)
    {
        speedMultiplier = _speedMultiplier;
        UpdateStat();
    }

    public void SetDamage(float _damageMultiplier)
    {
        damageMultiplier = _damageMultiplier;
        UpdateStat();
    }

    public void SetFireRate(float _fireRateMultiplier)
    {
        fireRateMultiplier = _fireRateMultiplier;
        UpdateStat();
    }

    private void UpdateStat()
    {
        speed = new Vector2(type.speed * speedMultiplier, type.speed * speedMultiplier);
        damage = type.damage * damageMultiplier;
        fireRate = type.GetFireRate() * fireRateMultiplier;
    }
}
