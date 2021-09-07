using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(Collider2D))]
public class ShieldManager : MonoBehaviour
{
    HealthBar health;
    Collider2D collide;

    private void Start()
    {
        collide = GetComponent<Collider2D>();
        health = GetComponent<HealthBar>();
        health.Init();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<EnemyAgent>().type;
            health.TakeDamage(enemy.damage);
        }
    }
}
