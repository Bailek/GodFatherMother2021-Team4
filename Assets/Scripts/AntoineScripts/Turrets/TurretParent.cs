using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretParent : MonoBehaviour
{
    public TurretStats turretStats;
    
    [HideInInspector]
    public GameObject _currentTarget;
    
    [HideInInspector]
    public long _lastTargetUpdate;
    
    [HideInInspector]
    public long _lastShoot;
    
    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = turretStats.radius;
    }
    
    public void rotateToTarget()
    {
        if (_currentTarget != null)
        {
            Vector3 vectorToTarget = getVectorToTarget();
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
            float _lastDistance = Vector3.Distance(transform.position, collidersInRange[0].transform.position);
            GameObject _lastTarget = collidersInRange[0].gameObject;
            for (int i = 1; i < collidersInRange.Length; i++)
            {
                if (collidersInRange[i].gameObject.tag.Contains("Enemy"))
                {
                    float distance = Vector3.Distance(transform.position, collidersInRange[i].transform.position);
                    if (distance < _lastDistance)
                    {
                        _lastTarget = collidersInRange[i].gameObject;
                        _lastDistance = distance;
                    }
                }
            }
            _currentTarget = _lastTarget.gameObject;
        }
        else
        {
            _currentTarget = null;
        }
        _lastTargetUpdate = (long) (Time.fixedTime + turretStats.targetUpdateInterval);
    }
    
    public virtual void shootTarget(){}
    
    public Vector3 getVectorToTarget()
    {
        return _currentTarget.transform.position - transform.position;
    }
}
