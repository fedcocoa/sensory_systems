using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVisionTest : MonoBehaviour
{
    public float length;
    RaycastHit[] rchits;
    Vector3 rayDir = Vector3.forward;
    public bool DebugView;
    public GameObject tracking;

    void Start()
    {
        rchits = new RaycastHit[4];
    }

    void Update()
    {
        bool hit = Physics.Raycast(gameObject.transform.position, rayDir, out rchits[0], length);
        if(DebugView)
        {
            Debug.DrawLine(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + length), Color.red);
        }
        if (!hit)
        {
            Debug.Log("Ray didn't hit anything.");
        }
        else
        {
            tracking = rchit.transform.gameObject;
            Debug.Log("Ray hit " + rchit.collider.name);
        }

    }
}
