using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/EnemyShip", fileName = "New Enemy ship")]
public class EnemyShip : Enemy
{
    public int fireRate = 10;
    public Sprite spriteBullet;
    public float fireRateMultipler = 1.0f;
    public float damageMultiplier = 1.0f;

    //public ShotComponent shotType;

    public override void OnDestroy()
    {
        //Feedback
        base.OnDestroy();
    }
}
