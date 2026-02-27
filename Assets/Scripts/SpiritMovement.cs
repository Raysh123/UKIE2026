using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SpiritMovement : MonoBehaviour
{
    public bool shieldActive = false;
    private bool isMoving;
    [SerializeField]
    private BPM bpm;
    private bool leftBlocked = false;
    private bool rightBlocked = false;

    public Health health;
    public ItemPickUp item;
    
    public SceneController sceneController;

    private void Start()
    {
        Health health = gameObject.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBlock"))
        {
            leftBlocked = true;
        }
        if (collision.gameObject.CompareTag("RightBlock"))
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
        if (Input.GetKeyDown(KeyCode.D) && bpm.beatHit && !isMoving && !rightBlocked)
        {
            StartCoroutine(MoveLeftOnBeat());
        }

        if (Input.GetKeyDown(KeyCode.A) && bpm.beatHit && !isMoving && !leftBlocked)
        {
            StartCoroutine(MoveRightOnBeat());
        }

        if (Input.GetKeyDown(KeyCode.D) && !bpm.beatHit && !isMoving)
        {
            Debug.Log("You SUck");
        }

        if (Input.GetKeyDown(KeyCode.A) && !bpm.beatHit && !isMoving)
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


    //public void Deactivate()
    //{
    ////    sceneController.gameOverActive = true;
    ////    sceneController.gameOverUI.SetActive(true);
    ////    sceneController.audioSource.Stop();
    ////    gameObject.SetActive(false);
    ////    Time.timeScale = 0f;
    ////}
}
