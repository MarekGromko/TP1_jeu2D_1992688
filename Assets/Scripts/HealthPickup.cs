using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public string targetTag;
    public int health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag) && collision.GetComponent<HealthState>() != null)
        {
            var hp = collision.GetComponent<HealthState>();
            if (health > 0)
                hp.Regen(health);
            else
                hp.Damage(health, transform);
            Destroy(gameObject);
        }
    }
}
