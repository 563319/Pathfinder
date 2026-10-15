
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
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        //do idle

        //idle animation
        anim.SetBool("isIdle", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", false);
        //

        UIscript.ui.DrawText("*** This is the idle state ***\n");
        
        if (nav.velocity.magnitude > 0)
        {
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