using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [Serializable]
    public class HealthState
    {
        public Sprite sprite;
    }
    [Serialize]
    public List<HealthState> states = new List<HealthState>();
    private int maxHealth;
    private int currentHealth;

    private void Awake()
    {
        maxHealth = states.Count;
        currentHealth = states.Count;
        GetComponent<SpriteRenderer>().sprite = states[currentHealth - 1].sprite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HealShip();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            Destroy(other.gameObject);
            DamageShip();
        }
    }

    private void DamageShip()
    {
        currentHealth--;
        UpdateState();
    }

    private void HealShip()
    {
        if (currentHealth + 1 <= maxHealth)
        {
            currentHealth++;
            UpdateState();
        }
    }

    private void UpdateState()
    {
        if (currentHealth > 0)
        {
            GetComponent<SpriteRenderer>().sprite = states[currentHealth - 1].sprite;
        }
        else
        {
            //Death
            Debug.LogWarning("Death");
            // Destroy(gameObject);
        }
    }
}
