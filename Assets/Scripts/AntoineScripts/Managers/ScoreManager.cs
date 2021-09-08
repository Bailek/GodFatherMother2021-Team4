using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    
    public float speedFactor = 1;
    public Text scoreText;
    
    private double score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        score += speedFactor * Time.deltaTime;
        scoreText.text = ((long) score).ToString();
    }
}
