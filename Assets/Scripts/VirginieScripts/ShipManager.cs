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
            float damage = collision.gameObject.GetComponent<EnemyAgent>().damage;
            health.TakeDamage(damage);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            float damage = collision.gameObject.GetComponent<EnemyBullet>().damage;
            health.TakeDamage(damage);
            Destroy(collision.gameObject);
        }

        

    }
}
