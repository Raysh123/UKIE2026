using System.Collections;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField]
    private BPM bpm;

    private bool isMoving = false;

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
    }

    private IEnumerator MoveOnBeat()
    {
        isMoving = true;
        transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(.50f);
        isMoving = false;
    }
    

}
