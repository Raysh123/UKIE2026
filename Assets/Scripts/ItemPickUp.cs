using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
 
    public SpiritMovement spirit;
    public PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spirit.shieldActive = true;            
            spirit.item = gameObject.GetComponent<ItemPickUp>();
            playerController.playerPickUpSFX.Play();
            Destroy(gameObject);
        }
    }
}
