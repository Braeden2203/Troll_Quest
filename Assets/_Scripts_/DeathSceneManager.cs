using UnityEngine;
using UnityEngine.UI;

public class DeathSceneManager : MonoBehaviour
{
    public GameObject GameManager;

    [SerializeField] Button MenuButton;
    [SerializeField] Button QuitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuClick()
    {
        GameManager.GetComponent<MainMenuManager>().LoadMenu();
    }

    public void OnQuitClick()
    {
        GameManager.GetComponent<MainMenuManager>().QuitGame();
    }
}
