using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRay : MonoBehaviour
{
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
        
        Color color = GetComponent<SpriteRenderer>().color;
        color = new Color(color.r, color.g, color.b, color.a - (1f * Time.deltaTime));
        GetComponent<SpriteRenderer>().color = color;
    }
}
