using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject gameOverUI;
    public bool gameOverActive;
    public AudioSource audioSource;

    private void Start()
    {
        gameOverActive = false;
    }

    public static void LoadScene(int sceneIndex)
   {
       SceneManager.LoadScene(sceneIndex);
   }

    public void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        gameOverActive = false;
    }

    public static void NextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void Quit()
    {
        Application.Quit();
    }
}
