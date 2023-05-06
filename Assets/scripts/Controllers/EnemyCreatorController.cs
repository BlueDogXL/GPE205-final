using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorController : Controller
{
    public enum AIState { Idle, Active };
    public AIState currentState;
    // Start is called before the first frame update
    public override void Start()
    {
        ChangeState(AIState.Active);
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
        base.Update();
    }

    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Idle:

                ChangeState(AIState.Active); 
                break;
            case AIState.Active:
                DoActiveState(); 
                break;
        }
    }
    public void ChangeState(AIState newState)
    {
        Debug.Log("enemy spawner active!");
        currentState = newState;
    }
    public void DoIdleState()
    {
        // *brian david gilbert voice* there's NOTHING HERE!
    }
    public void DoActiveState()
    {
        Debug.Log("Enemy spawned!");
        pawn.Shoot();
    }
    public void OnDestroy()
    {
        Destroy(pawn);
    }
}
