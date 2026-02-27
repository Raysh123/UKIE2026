using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public SpiritMovement spiritMovement;
    public Health health;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        spiritMovement = collision.GetComponent<SpiritMovement>();
        if (health != null)
        {
            {
                if(spiritMovement.shieldActive)
                {
                    spiritMovement.shieldActive = false;
                    Destroy(gameObject);
                }
                else
                {
                    health.TakeDamage(damage); 
                    Destroy(gameObject);
                }
            }
        }
    }
}
