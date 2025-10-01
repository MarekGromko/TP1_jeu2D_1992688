using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateEntrance : MonoBehaviour
{
    public float randomOffset = .5f;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        var offset = Random.insideUnitCircle;
        this.transform.position += (Vector3)offset * randomOffset;
        animator.SetFloat("EnterX", offset.x);
        animator.SetFloat("EnterY", offset.y);
        animator.SetTrigger("Enter");
    }
}
