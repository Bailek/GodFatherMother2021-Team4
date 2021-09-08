using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/EnemyShip", fileName = "New Enemy ship")]
public class EnemyShip : Enemy
{
    public float fireRate = 10.0f;
    public Sprite spriteBullet;

    public override void OnDestroy()
    {
        //Feedback
        base.OnDestroy();
    }

    public override float GetFireRate()
    {
        return this.fireRate;
    }
}
