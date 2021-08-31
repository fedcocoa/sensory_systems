using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTest : MonoBehaviour
{

    public enum Behaviour
    {
        Idle,
        Inspecting,
        Pursuing,
    }

    Behaviour currentState;
    NewVisionTest Vision;
    Hearing Hearing;
    MovementTest Movement;

    public Dictionary<string, int> Speeds = new Dictionary<string, int>();

    void Start()
    {
        //Get references to all the sub-systems
        Vision = gameObject.GetComponent<NewVisionTest>();
        Hearing = gameObject.GetComponent<Hearing>();
        Movement = gameObject.GetComponent<MovementTest>();

    }

    void Update()
    {


        switch (currentState)
        {
            case Behaviour.Idle:
                //test for objectives in the area
                //get to them if there are any
                //or get closer to the player
                break;
            case Behaviour.Inspecting:
                //use sensors to test for player or object of interest

                break;
            case Behaviour.Pursuing:
                //start the pursuing timer 
                //chase the player
                //if the player is close enough, attack the player
                //once the timer is up, move to a different area
                break;
        }

    }

    public Behaviour GetState()
    {
        return currentState;
    }

    public void SwitchState(Behaviour newState)
    {
        currentState = newState;
        Movement.SetSpeed(Speeds[currentState.ToString()]);
        Debug.Log(string.Format("Switched to {0} state!", currentState));
    }

}
