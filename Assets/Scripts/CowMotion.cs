using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(HealthState))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CowAttack))]
public class CowMotion : MonoBehaviour
{
    public float speed = 3.2f;
    private Rigidbody2D rb;
    private HealthState hp;
    private Animator animator;
    private Transform target;
    private Vector2 grassTarget;
    private CowAttack atkState;
    private Vector2 reqMotion;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<HealthState>();
        atkState = GetComponent<CowAttack>();
        animator = GetComponent<Animator>();
        hp.OnDamage += OnDamage;
    }
    void Start()
    {
        grassTarget = transform.position;
    }
    void OnDamage(int damage, Transform target)
    {
        this.target = target;
    }
    /**
    Compute the "AI" of the cow
    */
    void ComputeMotion()
    {
        if (atkState.IsAttacking())
        {
            reqMotion = Vector2.zero;
            animator.SetBool("IsMoving", false);
            animator.SetFloat("MoveX", 0f);
            return;
        }
        if (target != null)
        {
            var a = (Vector2)transform.position;
            var b = (Vector2)target.position;

            b.x += Vector2.Dot(Vector2.right, (a - b).normalized) > 0 ? .8f : -.8f;
            reqMotion = (b - a).normalized * speed;
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", reqMotion.x);
            if (Vector2.Distance(b, a) > 5.0f)
            {
                grassTarget = this.transform.position;
                this.target = null;
            }
            if (Vector2.Distance(b, a) < 0.3f)
                {
                    animator.SetFloat("MoveX", (target.position - transform.position).x);
                    atkState.StartAttack();
                }
        }
        else
        {
            if (Vector2.Distance(grassTarget, transform.position) < 0.2)
            {
                reqMotion = Vector2.zero;
                animator.SetBool("IsMoving", false);
                animator.SetFloat("MoveX", 0);
                if (Random.Range(0f, 1f) < 0.005f)
                {
                    grassTarget = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized * Random.Range(2f, 6f);
                }
            }
            else
            {
                reqMotion = (grassTarget - (Vector2)transform.position).normalized;
                animator.SetBool("IsMoving", true);
                animator.SetFloat("MoveX", reqMotion.x);
            }
        }
    }
    void FixedUpdate()
    {
        if (hp.IsDead()) return;
        ComputeMotion();
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * reqMotion);
    }
}
