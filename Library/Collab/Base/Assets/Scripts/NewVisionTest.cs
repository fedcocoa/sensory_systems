using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVisionTest : MonoBehaviour
{
    RaycastHit[] rchits;
    Vector3[] ends;
    public GameObject tracking;
    public bool DebugView;
    public int size;
    public float width;
    public float height;
    public float depth;
    public Color rayColor;
    public Color rayHitColor;
    public Timer timer;
    GameObject castTo;
   
    void Start()
    {
        //create new arrays
        rchits = new RaycastHit[size*size];
        ends = new Vector3[size*size];
        //get reference to timer
        timer = gameObject.GetComponent<Timer>();

        castTo = new GameObject("cast to");
        castTo.transform.parent = gameObject.transform;
        castTo.transform.position = gameObject.transform.position + gameObject.transform.forward;
    }

    //Generates all the vector3 directions that the rays will be cast towards
    void generateEnds()
    {
        int i = 0;
        for (int x = 0; x != size; x++)
        {
            for (int y = 0; y != size; y++)
            {
                ends[i] = new Vector3(castTo.transform.position.x, castTo.transform.position.y,depth);
                //ends[i] = new Vector3(castTo.transform.position.x + (x * width) - (width*(size-1))/2 , castTo.transform.position.y + (y * height) - (height * (size - 1))/2, castTo.transform.position.z + depth);
                i++;
            }
        }
    }

    //casts all the rays
    void raycastAll()
    {
        for(int i = 0; i != size *size; i++)
        {
            Physics.Raycast(gameObject.transform.position, ends[i], out rchits[i], depth);
        }
    }

    //checks all the raycast hits for what they hit
    void checkHits()
    {
        bool clearPass = true; //help determine if all the rays spotted nothing of interest
        for (int i = 0; i != size * size; i++)
        {
            if(rchits[i].collider != null)
            {
                //player and objects of interest checking
                if(rchits[i].collider.gameObject.tag == "Player")
                {
                    clearPass = false;
                    tracking = rchits[i].collider.gameObject;
                    if (timer.GetState() != Timer.TimerState.running)
                    {
                        Debug.Log("spotted player");
                        timer.StartTimer();
                    }
                } else
                {
                    if(rchits[i].collider.gameObject.tag == "Interest")
                    {
                        clearPass = false;
                    }
                }
                
            } 
        }
        if (clearPass)
        {
            Debug.Log("clear pass");
            //lost sight
            tracking = null;
            timer.ResetTimer();
        }
    }

    //draw the rays in the editor
    void drawLines()
    {
        for (int i = 0; i != size*size; i++)
        {
            if(rchits[i].collider != null)
            {
                Debug.DrawRay(gameObject.transform.position, ends[i], rayHitColor);
            } else
            {
                Debug.DrawRay(gameObject.transform.position, ends[i], rayColor);
            }
            
        }
    }

    void Update()
    {

        raycastAll();
        checkHits();
        if(DebugView)
        {
            drawLines();
        }

        if(timer.Done())
        {
            //Player spotted for length of the timer
            Debug.Log("Timer done");
        } else
        {
            Debug.Log(timer.TimeLeft());
        }

    }
}
