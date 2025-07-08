using System.Collections;
using UnityEngine;

public class TestEnemyAI : EnemyAI
{
    //Pass turn
    public override void Attack()
    {
        StartCoroutine(PauseBeforeEndingTurn());
    }

    private IEnumerator PauseBeforeEndingTurn()
    {
        //Debug.Log("I'm going to end my turn!");
        FindFirstObjectByType<AudioManager>().Play("TestEndTurn");
        yield return new WaitForSeconds(2);
        EndEnemyTurn();
    }
}
