using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    float length = 5f;
    RaycastHit rchit;
    Vector3 rayStart;
    Vector3 rayDir = Vector3.forward;
    public bool DebugView;
    public GameObject tracking;

    void Start()
    {
        rayStart = gameObject.transform.position;
        rchit = new RaycastHit();
    }

    void Update()
    {
        bool hit = Physics.Raycast(rayStart, rayDir, out rchit, length);
        if(DebugView)
        {
            Debug.DrawLine(rayStart, new Vector3(rayStart.x, rayStart.y, rayStart.z + length), Color.red);
        }
        if (!hit)
        {
            Debug.Log("Ray didn't hit anything.");
        }
        else
        {
            tracking = rchit.transform.gameObject;
            Debug.Log("Ray hit " + tracking.name);
        }

    }
}
