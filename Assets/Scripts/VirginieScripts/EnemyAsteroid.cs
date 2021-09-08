using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Asteroid", fileName = "New Asteroid")]
public class EnemyAsteroid : Enemy
{
    public override void OnDestroy()
    {
        //Feedback
        base.OnDestroy();
    }
}
