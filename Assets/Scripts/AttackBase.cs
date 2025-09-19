using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
/**
Base class that other behaviors may inherit to create zone of collision
*/
public class AttackBase : MonoBehaviour
{
    public string targetTag;
    public int damage = 1;
    private bool isAttacking = false;
    public bool IsAttacking() => isAttacking;
    protected Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void StartAttack()
    {
        if (isAttacking) return;
        isAttacking = true;
        animator.SetTrigger("Attack");
    }
    public void EndAttack()
    {
        isAttacking = false;
    }
    protected void ComputeAttack(Collider2D atk)
    {
        var collisions = new List<Collider2D>();
        Physics2D.OverlapCollider(atk, collisions);
        foreach (var other in collisions)
        {
            if (!other.CompareTag(targetTag) || other.GetComponent<HealthState>() == null)
                continue;
            var otherHealth = other.GetComponent<HealthState>();
            otherHealth.Damage(damage, transform);
        }
    }
}

