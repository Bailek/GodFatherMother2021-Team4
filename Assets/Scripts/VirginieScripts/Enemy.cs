using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public int damage = 100;
    public int health = 1;
    public int speed = 100;

    public Sprite sprite;

    public virtual void OnDestroy()
    {
        //FeedBack
    }
}
