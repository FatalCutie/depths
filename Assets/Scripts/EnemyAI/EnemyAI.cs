using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public int priority { get; private set; }
    public System.Action PassToCombatManager;
    public abstract void Attack();

    //Gives control back to CombatManager
    public void EndEnemyTurn()
    {
        PassToCombatManager?.Invoke();
    }

}