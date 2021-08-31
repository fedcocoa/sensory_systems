using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{

    public float radius;
    public bool debugView;
    SphereCollider receiver;
    GameObject debugSphere;

    void Start()
    {
        debugSphere = gameObject.transform.GetChild(0).gameObject;
        receiver = gameObject.GetComponent<SphereCollider>();
    }

    void Update()
    {
        receiver.radius = radius / 2;
        debugSphere.transform.localScale = new Vector3(radius,radius,radius);
        debugSphere.GetComponent<MeshRenderer>().enabled = debugView;
    }
  

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Sound")
        {
            Debug.Log("Hit a sound!");
        }
    }

}
