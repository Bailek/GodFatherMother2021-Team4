using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject pausePanel;
    private bool _isPaused = false;
    
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
        
        pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        _isPaused = true;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        _isPaused = false;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
