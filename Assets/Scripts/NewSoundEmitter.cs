using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSoundEmitter : MonoBehaviour
{

    public int rotations;
    Vector3[] directions;

    void Start()
    {
        directions = new Vector3[rotations];
        generateDirections();
        drawRays();
    }

    void generateDirections()
    {
        for(int i = 0; i != rotations; i++)
        {
            directions[i] = new Vector3(0,(360/rotations)*i,0);
        }
    }

    void drawRays()
    { 
        for(int i = 0; i != rotations; i++)
        {
            Debug.DrawRay(gameObject.transform.position, directions[i], Color.red,Mathf.Infinity);
        }
    }
    

    
}
