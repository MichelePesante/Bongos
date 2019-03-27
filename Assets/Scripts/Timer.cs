using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float timer = 0f;

    public void TickTimer()
    {
        timer += Time.deltaTime;
    }

    public void StopTimer()
    {
        timer = 0f;
    }

    public float GetTimer()
    {
        return timer;
    }

    public void SetTimer(float value)
    {
        timer = value;
    }

    /// <summary>
    /// Se il timer è più piccolo del parametro ritorna false, altrimenti true
    /// </summary>
    public bool CheckTimer(float comparedTime)
    {
        if (timer <= comparedTime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
