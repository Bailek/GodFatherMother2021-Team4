using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2.0f;
    [HideInInspector] public float damage = 0.0f;

    private ShipManager shipManager;
    private GameObject ship;
    private Transform target;

    private void Start()
    {
        shipManager = ShipManager.Instance;
        if (shipManager == null) return;

        ship = shipManager.gameObject;
        target = ship.transform;
    }
    private void Update()
    {
        if(shipManager != null)
        {
            Vector2 vBulletShip = target.position - transform.position;
            Vector2 dirBullet = vBulletShip.normalized;
            Vector2 velocity = dirBullet * speed * Time.fixedDeltaTime;

            transform.position += (Vector3)velocity;
        }
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
}
