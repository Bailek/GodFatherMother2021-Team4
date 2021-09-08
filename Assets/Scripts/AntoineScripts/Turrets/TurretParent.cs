using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretParent : MonoBehaviour
{
    public TurretStats turretStats;
    
    [HideInInspector]
    public GameObject _currentTarget;
    
    [HideInInspector]
    public float _lastTargetUpdate;
    
    [HideInInspector]
    public float _lastShoot;
    
    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = turretStats.radius;
    }
    
    public void rotateToTarget()
    {
        if (_currentTarget != null)
        {
            Vector3 vectorToTarget = getVectorToTarget(_currentTarget);
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turretStats.rotateSpeed);
        }
    }
    public void updateTarget()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, turretStats.radius);
        if (collidersInRange.Length > 0)
        {
            float _lastDistance = 10000;
            GameObject _lastTarget = null;
            for (int i = 0; i < collidersInRange.Length; i++)
            {
                if (collidersInRange[i].gameObject.CompareTag("Enemy"))
                {
                    float distance = Vector3.Distance(transform.position, collidersInRange[i].transform.position);
                    if (distance < _lastDistance)
                    {
                        _lastTarget = collidersInRange[i].gameObject;
                        _lastDistance = distance;
                    }
                }
            }
            _currentTarget = _lastTarget;
        }
        else
        {
            _currentTarget = null;
        }
        _lastTargetUpdate = Time.fixedTime + turretStats.targetUpdateInterval;
    }
    
    public virtual void shootTarget(){}
    
    public Vector3 getVectorToTarget(GameObject target)
    {
        return target.transform.position - transform.position;
    }
}
