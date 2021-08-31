using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolly : MonoBehaviour
{

    float time;
    public Vector3 start;
    public Vector3 end;
    public float increment = 0.01f;
    int flip = 1;

    void FixedUpdate()
    {
        if (time >= 1.0f | time < 0f)
        {
            flip *= -1;
        }
        time += increment * flip;
        gameObject.transform.position = Vector3.Lerp(start, end, time);
    }
}
