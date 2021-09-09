using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxPlanet : ParallaxSystem
{
    public override void Update()
    {
        base.Update();
        if (transform.position.x < -camWidth)
        {
            float xPos = camWidth;
            float yPos = Random.Range(-camHeight /2, camHeight /2);
            transform.position = new Vector3(xPos, yPos, 0);
        }
    }
}
