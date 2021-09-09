using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "", fileName = "New Turret")]
public class TurretStats : ScriptableObject
{
    public float radius;
    public float rotateSpeed;
    public float fireRate;
    public float targetUpdateInterval;
    public int damage;
}
