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
    private Animator anim;
    [SerializeField]
    private GameObject animViz;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
        animator = bpm.GetComponent<Animator>();
        anim = animViz.GetComponent<Animator>();
        

    }
    private void Update()
    {

        if (!jobDone && Time.timeSinceLevelLoad >= 2f)
        {
            audioSource.Play();            
            StartCoroutine(JobDone());
        }

    }

    IEnumerator JobDone()
    {
        jobDone = true;

        yield return new WaitForSeconds(.2f);
        animator.Play("BPM");
        anim.Play("BPMViz");

        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);

    }
}
