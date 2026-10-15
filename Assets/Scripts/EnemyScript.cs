using Unity.AI.Navigation.LowLevel;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    StateMachine sm;

    public int destPoint;
    public Transform[] points;
    void Start()
    {
        sm = new StateMachine(this); //"this" means - pass a reference of this script (player script) to the statemachine
        sm.Init(sm.patrolState); //this will be the first state to run

    }
    private void Update()
    {
        sm.Update();
    }

    void FixedUpdate()
    {
        sm.FixedUpdate();
        //below code needs to be moved
        
    }
    //add your additional collision handling here
    void OnCollisionEnter(Collision collision)
    {
        sm.currentState.OnCollisionEnter(collision);
    }
    void OnTriggerEnter(Collider collision)
    {
        sm.currentState.OnTriggerEnter(collision);
    }
    void OnTriggerExit(Collider collision)
    {
        sm.currentState.OnTriggerExit(collision);
    }
}
