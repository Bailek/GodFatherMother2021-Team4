using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public static Spaceship instance;

    [Serializable]
    public class HealthState
    {
        public float minHealthPercentage;
        public Sprite sprite;
    }
    [Serialize]
    public List<HealthState> states = new List<HealthState>();
    public float maxHealth;
    public float currentHealth;

    
    private void Awake()
    {
        
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        
        currentHealth = maxHealth;
        GetComponent<SpriteRenderer>().sprite = states[0].sprite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HealShip(20);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            Destroy(other.gameObject);
            DamageShip(20);
        }
    }

    private void DamageShip(int damage)
    {
        currentHealth -= damage;
        UpdateState();
    }

    private void HealShip(float value)
    {
        StartCoroutine(healProcess(value));
    }

    IEnumerator healProcess(float value, float seconds = 10f)
    {
        float healPerSec = value / seconds;
        Debug.Log("step " + healPerSec);

        while (value > 0)
        {
            currentHealth += healPerSec;
            value -= healPerSec;
            Debug.Log("heal " + currentHealth);
            UpdateState();
            yield return new WaitForSeconds(1f);
        }
        
        yield return null;
    }

    private void UpdateState()
    {
        if (currentHealth > 0)
        {
            int index = 0;
            for (int i = 0; i < states.Count; i++)
            {
                if (currentHealth <= states[i].minHealthPercentage)
                {
                    index = i;
                }
                else
                {
                    break;
                }
            }
            GetComponent<SpriteRenderer>().sprite = states[index].sprite;
        }
        //else
        //{
        //    //Death
        //    GameManager.instance.EndGame();
        //}
        Debug.Log(currentHealth);
    }
}
