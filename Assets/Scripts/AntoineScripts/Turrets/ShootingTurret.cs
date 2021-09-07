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
        
        if (Time.fixedTime > _lastTargetUpdate)
        {
            updateTarget();
        }

        if (Time.fixedTime > _lastShoot)
        {
            shootTarget();
        }
    }

    public override void shootTarget()
    {
        RaycastHit hit;
        Physics.Raycast( transform.position, transform.up, out hit, turretStats.radius);
        Debug.Log(hit.collider);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag.Contains("Enemy"))
            {
                GameObject bullet = Instantiate(bulletPrefab, transform);
                bullet.transform.SetParent(null);
                bullet.GetComponent<Bullet>().target = hit.collider.gameObject.transform.position;
            }
        }
        _lastShoot = (long) (Time.fixedTime + turretStats.fireRate);
    }
}
