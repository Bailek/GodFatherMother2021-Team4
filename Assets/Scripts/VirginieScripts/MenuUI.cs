using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public bool isMenuOpen, isOptionsOpen;
    public GameObject panelMenu;
    public Button buttonPlay, buttonOptions, buttonQuit;
    void Awake()
    {
        isMenuOpen = true;
        isOptionsOpen = false;
        buttonPlay.onClick.AddListener(Play);
        buttonOptions.onClick.AddListener(SwitchIsSettinged);
        buttonQuit.onClick.AddListener(Application.Quit);
    }
    void Update()
    {
        if (isOptionsOpen && Input.GetKeyDown(KeyCode.Escape)) SwitchIsSettinged();
    }

    void Play() { SceneManager.LoadScene("Game"); }
    void SwitchIsSettinged() { isOptionsOpen ^= true; }
}
