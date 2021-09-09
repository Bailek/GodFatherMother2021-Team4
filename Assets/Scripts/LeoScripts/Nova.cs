using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyAgent>())
        {
            other.gameObject.GetComponent<EnemyAgent>().takeDamage(10000);
        }
    }
}
