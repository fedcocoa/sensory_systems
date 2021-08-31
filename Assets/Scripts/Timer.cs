using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public string label;
    public float length;
    float timeLeft;
    float timeGone;
    TimerState state = TimerState.ready;

    //the different states a timer could take
    public enum TimerState
    {
        ready,
        running,
        finished,
        paused,
    }

    void Start()
    {
        timeLeft = length;
    }

    //testing if the timer is still running and if not, subtracting time from the time left
    //if the timer is done, the state is set to finished
    void Update ()
    {

        if(state == TimerState.running) {
            if (this.timeLeft >= 0f)
            {
                this.timeLeft -= Time.deltaTime;
                this.timeGone = length - timeLeft;
            }
            else
            {
                state = TimerState.finished;
            }
        }
    }

    public void StartTimer()
    {
        if(state != TimerState.ready)
        {
            Debug.Log(string.Format("Timer {0} wasn't ready!",label));
        } else
        {
            Debug.Log(string.Format("Timer {0} started!", label));
            state = TimerState.running;
        }
        
    }

    public void PauseTimer()
    {
        if(state == TimerState.paused)
        {
            Debug.Log(string.Format("Timer {0} was already paused!",label));
        } else
        {
            Debug.Log(string.Format("Timer {0} paused!", label));
            state = TimerState.paused;
        }
    }

    public void UnpauseTimer()
    {
        if(state == TimerState.paused)
        {
            Debug.Log(string.Format("Timer {0} unpaused!", label));
            state = TimerState.running;
        } else
        {
            Debug.Log(string.Format("Timer {0} couldn't be unpaused!", label));
        }
    }

    public void ResetTimer()
    {
        state = TimerState.ready;
        timeLeft = length;
        timeGone = 0f;
    }

    public TimerState GetState()
    {
        return state;
    }

    public bool Done()
    {
        return(state == TimerState.finished);
    }

    public float TimeLeft()
    {
        return timeLeft;
    }

    public float TimeGone()
    {
        return timeGone;
    }

}
