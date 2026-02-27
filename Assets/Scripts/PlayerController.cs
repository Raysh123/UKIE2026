using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    [SerializeField]
    private BPM bpm;
    private bool leftBlocked = false;
    private bool rightBlocked = false;
    public SceneController sceneController;
    private AudioSource movementSFX;
    public AudioSource playerPickUpSFX;  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("LeftBlock"))
        {
            leftBlocked = true;
        }
        if(collision.gameObject.CompareTag("RightBlock"))
        {
            rightBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBlock"))
        {
            leftBlocked = false;
        }
        if (collision.gameObject.CompareTag("RightBlock"))
        {
            rightBlocked = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.D) && bpm.beatHit && !isMoving && !rightBlocked)
        {
            StartCoroutine(MoveRightOnBeat());
        }

        if(Input.GetKeyDown(KeyCode.A) && bpm.beatHit && !isMoving && !leftBlocked)
        {
            StartCoroutine(MoveLeftOnBeat());
        }

        if(Input.GetKeyDown(KeyCode.D) && !bpm.beatHit && !isMoving)
        {
            Debug.Log("You SUck");
        }

        if(Input.GetKeyDown(KeyCode.A) && !bpm.beatHit && !isMoving)
        {
            Debug.Log("You SUck");
        }


    }
    private IEnumerator MoveLeftOnBeat()
    {
        isMoving = true;
        transform.position += new Vector3(-1, 0, 0);
        yield return new WaitForSeconds(.25f);
        isMoving = false;
    }
    private IEnumerator MoveRightOnBeat()
    {
        isMoving = true;
        transform.position += new Vector3(1, 0, 0);
        yield return new WaitForSeconds(.25f);
        isMoving = false;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        sceneController.gameOverUI.SetActive(true);
        sceneController.gameOverActive = true;
        Time.timeScale = 0f;
        sceneController.audioSource.Stop();
    }
}
