using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HealthState : MonoBehaviour
{
    public delegate void OnDamageHandler(int damage, Transform other);
    public event OnDamageHandler OnDamage;

    public int baseHealth;
    private int currentHealth;
    public int CurrentHealth() => currentHealth;
    private Animator animator;
    private bool isHurting = false;
    public bool IsHurting() => isHurting;
    public bool IsDead() => currentHealth == 0;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = baseHealth;
    }
    public void EndHurt()
    {
        isHurting = false;
    }
    public void EndDeath()
    {
        Destroy(this.gameObject);
    }
    public void Damage(int x, Transform other)
    {
        if (isHurting) return;
        currentHealth -= 1;
        OnDamage?.Invoke(x, other);
        if (IsDead())
        {
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
    }
}