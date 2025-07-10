using UnityEngine;

public class BleedDamage : MonoBehaviour
{
    public int damageRemaining;
    public int ticksRemaining;

    public BleedDamage(int damage, int ticks)
    {
        damageRemaining = damage;
        ticksRemaining = ticks;
    }
}
