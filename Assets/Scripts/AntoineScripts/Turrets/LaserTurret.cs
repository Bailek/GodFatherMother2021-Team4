using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : TurretParent
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
        RaycastHit2D[] hits = Physics2D.RaycastAll( transform.position, transform.right, turretStats.radius, layerMask);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {
                if (hits[i].collider.gameObject.GetComponent<EnemyAgent>())
                {
                    hits[i].collider.gameObject.GetComponent<EnemyAgent>().takeDamage(turretStats.damage);
                    GameObject canon = transform.GetChild(0).gameObject;
                    GameObject bullet = Instantiate(bulletPrefab, canon.transform);
                    bullet.transform.SetParent(null);
                    canon.GetComponent<Animator>().Play("PlayerTurretShoot");

                    _lastShoot = Time.time + turretStats.fireRate;
                }
            }
        }
    }
}
