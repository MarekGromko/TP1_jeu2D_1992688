using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(HealthState))]
public class PlayerMotion : MonoBehaviour
{
    public float speed = 5;
    private Animator animator;
    private HealthState hp;
    private Rigidbody2D rb;
    private Vector2 reqMotion;
    private PlayerAttack atkState;
    void Awake()
    {
        hp = GetComponent<HealthState>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        atkState = GetComponent<PlayerAttack>();
    }
    public void OnMove(InputValue input)
    {
        if (hp.IsDead()) return;
        if (reqMotion.sqrMagnitude > 0f)
        {
            animator.SetFloat("LastMoveX", reqMotion.x);
            animator.SetFloat("LastMoveY", reqMotion.y);
        }
        //
        reqMotion = input.Get<Vector2>();
        animator.SetFloat("MoveX", reqMotion.x);
        animator.SetFloat("MoveY", reqMotion.y);
        animator.SetBool("IsMoving", reqMotion.sqrMagnitude > 0f);
    }
    public void OnAttack(InputValue input)
    {
        if (hp.IsDead()) return;
        atkState.StartAttack();
    }
    void FixedUpdate()
    {
        if (hp.IsDead()) return;
        if (reqMotion.sqrMagnitude > 0f && !atkState.IsAttacking())
        {
            rb.MovePosition(rb.position + speed * Time.deltaTime * reqMotion.normalized);
        }
    }
}
