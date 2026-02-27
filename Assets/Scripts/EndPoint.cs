using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public SceneController sceneController;
    [SerializeField] private int sceneIndex;

    private void Start()
    {
        sceneController = FindAnyObjectByType<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

