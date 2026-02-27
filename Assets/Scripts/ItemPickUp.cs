using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
 
    public SpiritMovement spirit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //spirit.ActivateShield();
            spirit.shieldActive = true;            
            spirit.item = gameObject.GetComponent<ItemPickUp>();
            Destroy(gameObject);
        }
    }
}
