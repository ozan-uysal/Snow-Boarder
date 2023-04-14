using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FunctionTimer
{
    Action action;
    public float timer;

    public FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            action();
        }
    }
}
