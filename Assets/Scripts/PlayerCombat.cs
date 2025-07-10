using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Health currentTarget;
    private CombatModifiers cm;
    public GameObject attackGO;
    [SerializeField] private TimingSliderController timingSlider;
    [SerializeField] private AttackData currentAttack;

    void Start()
    {
        cm = FindFirstObjectByType<CombatModifiers>();
    }
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
        if (cm.DoesAttackCrit())
        {
            totalDamage *= cm.criticalHitDamageMultiplier;
            FindAnyObjectByType<AudioManager>().Play("Critical"); //TODO: Add critical sound
        }
        else FindAnyObjectByType<AudioManager>().Play("Attack");
        //Debug.Log($"Hit {zonesHit} zone(s)! Dealing {totalDamage} damage.");
        currentTarget.TakeDamage(totalDamage);
        if (FindFirstObjectByType<CombatManager>().AreThereEnemiesStillAlive()) StartCoroutine(EndTurn());
        else FindFirstObjectByType<CardDealer>().DecideNumberOfCardsToGenerate();
    }

    private IEnumerator EndTurn()
    {
        //TODO: Hide UI
        yield return new WaitForSeconds(1);
        EndPlayerTurn();
    }
    private void EndPlayerTurn()
    {
        //Debug.Log("I'm ending my turn!");
        FindFirstObjectByType<CombatManager>().DecideWhosTurnItIs();
    }
}