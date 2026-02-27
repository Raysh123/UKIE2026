using System.Collections;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField]
    private BPM bpm;

    private bool isMoving = false;
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = -0.5f;
    }

    private void Update()
    {
        if (bpm.beatHit && !isMoving)
        {
            StartCoroutine(MoveOnBeat());
        }
        else
        {
            return;
        }

        if(Time.timeSinceLevelLoad >= 150f)
        {
            moveSpeed = -1;
        }
    }

    private IEnumerator MoveOnBeat()
    {
        isMoving = true;
        transform.position += new Vector3(0, moveSpeed, 0);
        yield return new WaitForSeconds(.50f);
        isMoving = false;

    }
    

}
