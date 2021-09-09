using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public Vector3 target;

    public float lifetime;
    private float timeLeft;

    private void Start()
    {
        timeLeft = Time.fixedTime + lifetime;
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0) Destroy(gameObject);
        
        float step = speed * Time.deltaTime;
        transform.position += target * step;
    }
}
