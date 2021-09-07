using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public int damage = 1;
    public int health = 1;

    public virtual void OnDestroy()
    {
        //FeedBack
    }
}
