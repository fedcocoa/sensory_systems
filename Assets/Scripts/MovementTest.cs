using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementTest : MonoBehaviour
{

    NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void SetSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            Physics.Raycast(targetRay, out rayhit);
            Vector3 target = rayhit.point;
            agent.destination = target;
        }
        
    }
}
