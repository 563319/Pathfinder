
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class PatrolState : State
{
    //running speed var for example

    public PatrolState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entering patrolling state");
        //aniamtion setting
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", true);

    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void Update()
    {
        UIscript.ui.DrawText("\ndistance: " + distanceToPoint);
        distanceToPoint = nav.remainingDistance;// Vector3.Distance(enemy.transform.position, nav.destination);

        Debug.Log("d=" + distanceToPoint);
        Debug.Log("navPoint=" + nav.destination);

        

        //do patrolling
        //sm.ChangeState(sm.patrolState);
        UIscript.ui.DrawText("*** This is the patrolling state ***\n");
        //move to attack
        /*
        if (distanceToPoint <= attackRadius && enemyStillInRadius == false)
        {
            sm.ChangeState(sm.attackState);       
        }
        */


        //to idle
        if (nav.velocity.magnitude <= 0 )
        {
            sm.ChangeState(sm.idleState);
        }
        //move to next point
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
        //when point is in certain range switch to attack state

    }

    public override void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.CompareTag("Point"))
        {

            Debug.Log("collided with point via is trigger");
            sm.ChangeState(sm.attackState);
        }
    }

    public override void FixedUpdate()
    {
    }
}