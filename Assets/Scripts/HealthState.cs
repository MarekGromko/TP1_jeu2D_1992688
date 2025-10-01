using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HealthState : MonoBehaviour
{
    public delegate void OnDamageHandler(int damage, Transform other);
    public delegate void OnDeathHandler(Transform other);
    public delegate void OnChangeHandler(int change);
    public event OnDamageHandler OnDamage;
    public event OnDeathHandler OnDeath;
    public event OnChangeHandler OnChange;

    public int baseHealth;
    private int currentHealth;
    public int CurrentHealth() => currentHealth;
    private Animator animator;
    private bool isHurting = false;
    public bool IsHurting() => isHurting;
    public bool IsDead() => currentHealth <= 0;
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
        OnDeath?.Invoke(transform);
        gameObject.SetActive(false);
    }
    public void Damage(int x, Transform other)
    {
        if (IsHurting() || IsDead()) return;
        currentHealth = Math.Max(0, currentHealth - x);
        OnDamage?.Invoke(x, other);
        OnChange?.Invoke(-x);
        if (IsDead())
        {
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
    }
    public void Regen(int x)
    {
        currentHealth = Math.Min(baseHealth, currentHealth + x);
        OnChange?.Invoke(x);
        if (!IsHurting())
        {
            animator.SetTrigger("Regen");
        }
    }
}