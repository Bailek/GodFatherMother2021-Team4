using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public float health = 1.0f;
    public float damage = 10.0f;
    public float maxDamage = 20.0f;
    public float speed = 10.0f;
    public float maxSpeed = 20.0f;

    public Sprite sprite;
    public Sprite spriteOnDestroy;

    public virtual float GetFireRate()
    {
        return 0.0f;
    }

    public virtual float GetMaxFireRate()
    {
        return 0.0f;
    }
    public virtual void OnDestroy()
    {
        //Feedback
    }
}
