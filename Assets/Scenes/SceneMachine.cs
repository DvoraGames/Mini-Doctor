using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMachine : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
