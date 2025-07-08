using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<EnemyAI> enemyAIs;
    int timesLooped = 0;

    void Start()
    {
        InitializeEnemies();
    }
    //pupulate enemies list based on generated encounter
    public void InitializeEnemies()
    {
        enemyAIs = Resources.FindObjectsOfTypeAll<EnemyAI>().ToList(); //temp(?)
    }

    public void DecideWhosTurnItIs()
    {
        if (timesLooped >= enemyAIs.Count)
        {
            timesLooped = 0; //Reset for when player ends turn
            //Debug.Log("It's the players turn now!");
            return;
            //TODO: Start Players turn
        }

        enemyAIs[timesLooped].PassToCombatManager = DecideWhosTurnItIs; //Come back here when turn is over
        //Debug.Log("Passing control to the AI!");
        enemyAIs[timesLooped].Attack(); //Begin attack
        timesLooped++;
    }

    public bool AreThereEnemiesStillAlive()
    {
        foreach (EnemyAI e in enemyAIs)
        {
            GameObject go = e.gameObject;
            if (go.GetComponent<Health>().CurrentHP > 0)
            {
                Debug.Log(go.GetComponent<Health>().CurrentHP);
                continue;
            }
            else return false;
        }
        return true;
    }
}
