using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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
        int layerMask = 1 << 6;
        RaycastHit2D hit = Physics2D.Raycast( transform.position, transform.right, turretStats.radius, layerMask);
        if (hit.collider != null)
        {
            GameObject canon = transform.GetChild(0).gameObject;
            GameObject bullet = Instantiate(bulletPrefab, canon.transform);
            bullet.transform.SetParent(null);
            bullet.GetComponent<Bullet>().target = getVectorToTarget(hit.collider.gameObject);
            canon.GetComponent<Animator>().Play("PlayerTurretShoot");

            _lastShoot = Time.time + turretStats.fireRate;
        }
    }
}
