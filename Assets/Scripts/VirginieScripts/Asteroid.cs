using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Asteroid", fileName = "New Asteroid")]
public class Asteroid : Enemy
{   
    public override void OnDestroy()
    {
        //Feedback
    }
}
