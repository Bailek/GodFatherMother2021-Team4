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
    private void Update()
    {
        Vector2 vEnemyShip = ship.transform.position - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Debug.Log(dirEnemy);
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y) * dirEnemy * type.speed * Time.deltaTime;
        transform.position += (Vector3)newPos;
    }
}
