using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public int health = 1;
    public int damage = 10;
    public int speed = 10;
    public int maxSpeed = 20;

    public Sprite sprite;
    public Sprite spriteOnDestroy;
    public List<float> multipliers = new List<float>();
    public virtual List<float> GetMultiplier()
    {
        return multipliers;
    }
    public virtual void OnDestroy()
    {
        //Feedback
    }
}
