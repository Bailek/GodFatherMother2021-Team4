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
    private Vector3 saveVelocity;

    private void Start()
    {
        shipManager = ShipManager.Instance;
        if (shipManager == null) return;

        ship = shipManager.gameObject;
        target = ship.transform;

        CalculateVelocity();
    }
    private void Update()
    {
        MoveToShip();

        if (shipManager == null) return;
        RotateToShip();
    }

    public void CalculateVelocity()
    {
        Vector3 vBulletShip = target.position - transform.position;
        Vector3 dirBullet = vBulletShip.normalized;
        Vector3 velocity = dirBullet * speed * Time.deltaTime;
        saveVelocity = velocity;
    }
    public void MoveToShip()
    {
        transform.position += saveVelocity;
    }

    public void RotateToShip()
    {
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToTarget = ship.transform.position - forward;
        Vector3 dirForwardToTarget = vForwardToTarget.normalized;
        float angle = Mathf.Atan2(dirForwardToTarget.y, dirForwardToTarget.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
}
