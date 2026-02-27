using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
  public void LoadScene(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
