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
    private Vector2 saveVelocity;

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
            MoveToShip();
            RotateToShip();
        }
        else
        {
            ContinueMove();
        }
    }

    public void MoveToShip()
    {

        Vector3 vBulletShip = target.position - transform.position;
        Vector3 dirBullet = vBulletShip.normalized;
        Vector3 velocity = dirBullet * speed * Time.deltaTime;

        transform.position += velocity;

        saveVelocity = velocity;
    }

    public void ContinueMove()
    {
        transform.position += (Vector3)saveVelocity;
    }

    public void RotateToShip()
    {
        float angle = 0f;
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToTarget = ship.transform.position - forward;
        Vector3 dirForwardToTarget = vForwardToTarget.normalized;
        angle = Mathf.Atan2(dirForwardToTarget.y, dirForwardToTarget.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
}
