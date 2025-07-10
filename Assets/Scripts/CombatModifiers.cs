using System;
using System.Collections.Generic;
using UnityEngine;

public class CombatModifiers : MonoBehaviour
{
    public static CombatModifiers instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    #region Critical Hit
    public int criticalHitRate;
    public bool canPlayerCrit = false;
    public int criticalHitDamageMultiplier = 2;

    public bool DoesAttackCrit()
    {
        if (!canPlayerCrit) return false;
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance <= criticalHitRate) return true;
        return false;
    }
    #endregion

    #region Bleed
    public bool isBleedEnabled = false;
    public bool canBleedingStack = false;
    public int bleedPercentDamage = 10;
    public List<BleedDamage> bleedLog = new List<BleedDamage>(); //First int is damage remaining, second is ticks left 
    //Add add bleed to health script, have it managed there?
    public int CalculateBleedDamage()
    {
        int toReturn = 0;
        foreach (BleedDamage bd in bleedLog)
        {
            if (bd.ticksRemaining == 0) Destroy(bd);
            int damageDealt = 0;
            damageDealt = bd.damageRemaining / bd.ticksRemaining;
            bd.damageRemaining -= damageDealt;
            bd.ticksRemaining--;
            toReturn += damageDealt;
        }
        return toReturn;
    }

    //TODO: This will have to calculate per enemy
    public void AddBleedDamage(int damage)
    {
        if (!canBleedingStack) bleedLog[0] = new BleedDamage(damage, 3); //refresh original bleed if can't stack
        else bleedLog.Add(new BleedDamage(damage, 3));
    }

    #endregion
}
