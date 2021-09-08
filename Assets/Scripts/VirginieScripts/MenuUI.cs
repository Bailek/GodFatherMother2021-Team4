using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
class MenuUI : MonoBehaviour
{
    // Game State
    public bool isPaused, isMenued, isSettinged, isGameOvered;

    // UI Objects
    // | Layers
    GameObject Layer_Runtime, Layer_Pause, Layer_Menu, Layer_Settings, Layer_GameOver;

    // | Buttons
    Button Button_Resume, Button_Retry_P, Button_Retry_G, Button_Play, Button_Menu_P, Button_Menu_G, Button_Quit_P, Button_Quit_M, Button_Quit_G, Button_Settings_P, Button_Settings_M;
    void Awake()
    {
        // UI Objects

        // | Layers
        Layer_Runtime = GameObject.Find("Layer_Runtime");
        Layer_Pause = GameObject.Find("Layer_Pause");
        Layer_Menu = GameObject.Find("Layer_Menu");
        Layer_Settings = GameObject.Find("Layer_Settings");
        Layer_GameOver = GameObject.Find("Layer_GameOver");

        // | Buttons
        Button_Resume = GameObject.Find("Button_Resume").GetComponent<Button>();
        Button_Retry_P = GameObject.Find("Button_Retry_P").GetComponent<Button>();
        Button_Retry_G = GameObject.Find("Button_Retry_G").GetComponent<Button>();
        Button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
        Button_Menu_P = GameObject.Find("Button_Menu_P").GetComponent<Button>();
        Button_Menu_G = GameObject.Find("Button_Menu_G").GetComponent<Button>();
        Button_Quit_P = GameObject.Find("Button_Quit_P").GetComponent<Button>();
        Button_Quit_M = GameObject.Find("Button_Quit_M").GetComponent<Button>();
        Button_Quit_G = GameObject.Find("Button_Quit_G").GetComponent<Button>();
        Button_Settings_P = GameObject.Find("Button_Settings_P").GetComponent<Button>();
        Button_Settings_M = GameObject.Find("Button_Settings_M").GetComponent<Button>();

        // | Listeners
        Button_Resume.onClick.AddListener(SwitchIsPaused);
        Button_Retry_P.onClick.AddListener(Play);
        Button_Retry_G.onClick.AddListener(Play);
        Button_Play.onClick.AddListener(Play);
        Button_Menu_P.onClick.AddListener(Menu);
        Button_Menu_G.onClick.AddListener(Menu);
        Button_Quit_P.onClick.AddListener(Application.Quit);
        Button_Quit_M.onClick.AddListener(Application.Quit);
        Button_Settings_P.onClick.AddListener(SwitchIsSettinged);
        Button_Settings_M.onClick.AddListener(SwitchIsSettinged);
    }
    void Update()
    {
        // Game State
        Time.timeScale = isPaused ? 0 : isMenued ? 0 : 1;
        if (!isMenued && !isSettinged && Input.GetKeyDown(KeyCode.Escape)) SwitchIsPaused();
        if (isSettinged && Input.GetKeyDown(KeyCode.Escape)) SwitchIsSettinged();
        // UI Objects
        // | Layers
        Layer_Runtime.SetActive(!isPaused && !isMenued && !isGameOvered && !isSettinged);
        Layer_Pause.SetActive(isPaused && !isSettinged);
        Layer_Menu.SetActive(isMenued && !isSettinged);
        Layer_GameOver.SetActive(isGameOvered && !isSettinged);
        Layer_Settings.SetActive(isSettinged);
    }
    void SwitchIsPaused() { isPaused ^= true; }
    void Play() { SceneManager.LoadScene("Game"); }
    void Menu() { SceneManager.LoadScene("Menu"); }
    void GameOver() { SceneManager.LoadScene("GameOver"); }
    void SwitchIsSettinged() { isSettinged ^= true; }
}
