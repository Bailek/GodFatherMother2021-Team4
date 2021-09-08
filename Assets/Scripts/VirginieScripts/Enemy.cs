using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public int health = 1;
    public int damage = 100;
    public int speed = 100;
    public Sprite sprite;
    public Sprite spriteOnDestroy;

    public virtual void OnDestroy()
    {
        //Feedback
    }
}
