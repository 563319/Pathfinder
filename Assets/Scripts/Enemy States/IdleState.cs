
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class IdleState : State
{
    //running speed var for example

    public IdleState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering idle state");
        //idle animation
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", false);
        //
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        distanceToPoint = Vector3.Distance(enemy.transform.position, nav.destination);
        //do idle

       

        UIscript.ui.DrawText("*** This is the idle state ***\n");
        
        if (nav.velocity.magnitude > 0)
        {
            sm.ChangeState(sm.patrolState);
        }

        if (distanceToPoint <= attackRadius && enemyStillInRadius == false)
        {
            sm.ChangeState(sm.attackState);
        }



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}