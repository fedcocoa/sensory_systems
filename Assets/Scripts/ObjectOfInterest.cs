using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOfInterest : MonoBehaviour
{

    public string itemName;

    public void OnPickup()
    {
        Debug.Log(string.Format("{0} has been picked up!", itemName));
    }

}
