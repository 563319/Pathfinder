
//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected EnemyScript enemy;
    protected StateMachine sm;
    //
    public Animator anim;
    public NavMeshAgent nav;

    // base constructor
    public State(EnemyScript enemy, StateMachine sm)
    {
        this.enemy = enemy;
        this.sm = sm;
        this.anim = enemy.GetComponentInChildren<Animator>();
        this.nav = enemy.GetComponent<NavMeshAgent>();
    }

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter(Collision collision) { }
    public virtual void OnTriggerEnter(Collider collision) { }
    public virtual void OnTriggerExit(Collider collision) { }

    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public

    public void GoToNextPoint()
    {
        if (enemy.points.Length == 0)
        {
            return;
        }
        nav.destination = enemy.points[enemy.destPoint].position;
        enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;
    }
}