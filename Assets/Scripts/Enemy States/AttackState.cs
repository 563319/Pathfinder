
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class AttackState : State
{
    //running speed var for example

    public AttackState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering attacking state");
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        //do attacking

        //attack animation
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", true);
        anim.SetBool("isRunning", false);
        //
        UIscript.ui.DrawText("*** This is the attacking state ***\n");



    }

    public override void OnTriggerEnter(Collider collision)
    {

    }

    public override void FixedUpdate()
    {
    }
}