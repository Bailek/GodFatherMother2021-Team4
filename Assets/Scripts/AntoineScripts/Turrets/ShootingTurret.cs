using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : TurretParent
{
    public GameObject bulletPrefab;

    private void Update()
    {
        rotateToTarget();
        if (Time.time > _lastTargetUpdate)
        {
            updateTarget();
        }
        if (Time.time > _lastShoot)
        {
            shootTarget();
        }
    }

    public override void shootTarget()
    {
        int layerMask = 1 << 11;
        RaycastHit2D hit = Physics2D.Raycast( transform.position, transform.up, turretStats.radius, layerMask);
        if (hit.collider != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.transform.SetParent(null);
            bullet.GetComponent<Bullet>().target = getVectorToTarget(hit.collider.gameObject);
            
            _lastShoot = Time.time + turretStats.fireRate;
        }
    }
}
