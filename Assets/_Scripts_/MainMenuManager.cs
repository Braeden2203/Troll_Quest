using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class MainMenuManager : MonoBehaviour
{
    InputAction PauseGame;

    [SerializeField] Canvas MainMenuCanvas;

    bool IsSceneLoaded = false;
    bool GameActive = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        PauseGame = InputSystem.actions.FindAction("PauseGame");
    }

    private void Update()
    {
        if (PauseGame.IsPressed() && GameActive == true)
        {
            Time.timeScale = 0f;
            MainMenuCanvas.gameObject.SetActive(true);
        }
    }
    public void LoadScene(string SampleScene)
    {
        if (IsSceneLoaded == false)
        {
            SceneManager.LoadScene(SampleScene);
            MainMenuCanvas.gameObject.SetActive(false);
            IsSceneLoaded = true;
            GameActive = true;
        }
        else if (IsSceneLoaded == true)
        {
            Time.timeScale = 1f;
            MainMenuCanvas.gameObject.SetActive(false);
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadDeathScene()
    {
        SceneManager.LoadScene("DeathScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
