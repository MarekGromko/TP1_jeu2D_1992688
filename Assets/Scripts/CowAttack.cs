using UnityEngine;

public class CowAttack : AttackBase
{
    public Collider2D atk_east;
    public Collider2D atk_west;
    public void AtkE()=> ComputeAttack(atk_east);
    public void AtkW() => ComputeAttack(atk_west);
}
