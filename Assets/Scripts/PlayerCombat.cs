using Unity.Mathematics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Health currentTarget;
    public GameObject attackGO;
    [SerializeField] private TimingSliderController timingSlider;
    [SerializeField] private AttackData currentAttack;

    public void StartAttack()
    {
        if (currentTarget == null || currentAttack == null) return;

        timingSlider.OnZoneHitsComplete = HandleTimingResult; //Attack timings handled in slider
        timingSlider.StartTiming(currentAttack.scrollSpeed, currentAttack.timingZones);
    }

    //Attack
    private void HandleTimingResult(int zonesHit)
    {
        Instantiate(attackGO, currentTarget.transform.position, quaternion.identity); //Attack Animation
        int totalDamage = currentAttack.baseDamage + (zonesHit * currentAttack.bonusPerZoneHit);
        Debug.Log($"Hit {zonesHit} zone(s)! Dealing {totalDamage} damage.");
        currentTarget.TakeDamage(totalDamage);
    }
}