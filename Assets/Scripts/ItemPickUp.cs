using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public bool shieldActive = false;
    public SpiritMovement spirit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            spirit.ActivateShield();
            shieldActive = true;
        }
    }
}
