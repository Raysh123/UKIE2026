using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public SceneController sceneController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else if (!sceneController.gameOverActive)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        sceneController.audioSource.Play();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        sceneController.audioSource.Stop();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneController.LoadScene(9);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
