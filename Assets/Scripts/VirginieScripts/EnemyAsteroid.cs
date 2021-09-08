using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Asteroid", fileName = "New Asteroid")]
public class EnemyAsteroid : Enemy
{
    public float speedMultiplier = 1.0f;
    public override List<float> GetMultiplier()
    {
        multipliers.Add(speedMultiplier);
        return multipliers;
    }
    public override void OnDestroy()
    {
        //Feedback
        base.OnDestroy();
    }
}
