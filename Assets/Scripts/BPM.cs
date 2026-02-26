using UnityEngine;

public class BPM : MonoBehaviour
{
    public bool beatHit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Beat"))
        {
            beatHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Beat"))
        {
            beatHit = false;
        }
    }
}
