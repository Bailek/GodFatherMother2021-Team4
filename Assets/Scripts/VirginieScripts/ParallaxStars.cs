using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxStars : ParallaxSystem
{
    public override void Update()
    {
        base.Update();

        if (transform.position.x < -camWidth)
        {
            float xPos = camWidth;
            transform.position = new Vector3(xPos, 0, 0);
        }
    }
}
