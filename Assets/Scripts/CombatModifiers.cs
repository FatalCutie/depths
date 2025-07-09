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

    public bool DoesAttackCrit()
    {
        if (!canPlayerCrit) return false;
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance <= criticalHitRate) return true;
        return false;
    }
    #endregion
}
