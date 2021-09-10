using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        GameManager.instance.TogglePause();
    }

    public void Go2Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
