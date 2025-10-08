using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(VictoryCondition))]
public class PlayerAttack : AttackBase
{
    public Collider2D atk_north;
    public Collider2D atk_east;
    public Collider2D atk_south;
    public Collider2D atk_west;
    public void AtkN() => ComputeAttack(atk_north);
    public void AtkE() => ComputeAttack(atk_east);
    public void AtkS() => ComputeAttack(atk_south);
    public void AtkW() => ComputeAttack(atk_west);
}
