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
    private void FixedUpdate()
    {
        if(shipManager != null)
        {
            Vector2 vEnemyShip = ship.transform.position - transform.position;
            Vector2 dirEnemy = vEnemyShip.normalized;
            Vector2 speed = new Vector2(type.speed, type.speed);
            Debug.Log(dirEnemy);
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y) * dirEnemy * speed * Time.fixedDeltaTime;
            Debug.Log(newPos);
            transform.position += (Vector3)newPos;

            float angle = 0f;
            Vector3 forward = transform.position + Vector3.up;
            Vector3 vForwardToTarget = ship.transform.position - forward;
            Vector3 dirForwardToTarget = vForwardToTarget.normalized;
            angle = Mathf.Atan2(dirForwardToTarget.y, dirForwardToTarget.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Euler(0, 0, angle);

        }

    }
}
