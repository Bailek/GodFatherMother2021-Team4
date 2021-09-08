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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health.SetMaxHealth(type.health);
        spriteRenderer.sprite = type.sprite;
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
        if (shipManager != null)
        {
            MoveToTarget();
            RotateTowardShip();
        }
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

    private void MoveToTarget()
    {
        Vector2 vEnemyShip = target.position - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2 speed = new Vector2(type.speed, type.speed);
        Vector2.ClampMagnitude(speed, type.maxSpeed);
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;

        transform.position += (Vector3)velocity;
    }
}
