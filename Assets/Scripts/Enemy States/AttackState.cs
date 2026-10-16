
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AttackState : State
{
    public float attackTimer = 0f;
    //running speed var for example

    public AttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering attacking state");
        enemyStillInRadius = true;
        //attack animation
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", true);
        anim.SetBool("isRunning", false);
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        distanceToPoint = Vector3.Distance(enemy.transform.position, nav.destination);
        attackTimer += Time.deltaTime;
        //do attacking
        Debug.Log("distance: " + distanceToPoint);
        UIscript.ui.DrawText("\ndistance: " + distanceToPoint);

        Debug.Log("attack timer: " + attackTimer);
        //
        UIscript.ui.DrawText("*** This is the attacking state ***\n");
        if (distanceToPoint > attackRadius)
        {
            

            sm.ChangeState(sm.patrolState);

            
            
        }
        if (attackTimer >= 2.5)
        {
            Debug.Log("attack timer is >= 2.5");
            attackTimer = 0f;
            enemyStillInRadius = false;
            sm.ChangeState(sm.patrolState);
        }
    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}