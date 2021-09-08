using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(HealthUI))]
public class ShipManager : MonoBehaviour
{
    HealthBar health;
    public static ShipManager Instance { get; set; }
    private void Awake()
    {
        if (Instance != null) { Destroy(this.gameObject); return; }
        Instance = this;
    }
    private void Start()
    {
        health = GetComponent<HealthBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<EnemyAgent>().type;
            health.TakeDamage(enemy.damage);
            Destroy(collision.gameObject);
        }
    }
}
