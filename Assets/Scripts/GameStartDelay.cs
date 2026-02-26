using System.Collections;
using UnityEngine;

public class GameStartDelay : MonoBehaviour
{
    private bool jobDone;
    [SerializeField]
    private GameObject audioObject;
    private AudioSource audioSource;
    [SerializeField]
    private GameObject bpm;
    private Animator animator;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        animator = bpm.GetComponent<Animator>();
    }
    private void Update()
    {

        if (!jobDone && Time.timeSinceLevelLoad >= 2f)
        {
            audioSource.Play();
            animator.Play("BPM");
            StartCoroutine(JobDone());
        }

    }

    IEnumerator JobDone()
    {
        jobDone = true;

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);

    }
}
