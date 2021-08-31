using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerTest : MonoBehaviour
{

    public Timer timer;
    
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.length = 100f;
        timer.StartTimer();
        
    }
    
    void Update()
    {
        if(timer.TimeLeft() < 90f)
        {
            timer.PauseTimer();
        }
        Debug.Log(timer.TimeLeft());
        Debug.Log(timer.TimeGone());
    }
}
