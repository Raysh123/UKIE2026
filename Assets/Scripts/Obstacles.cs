using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Health health;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage); 
        }
    }
}
