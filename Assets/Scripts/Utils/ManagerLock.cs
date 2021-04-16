using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLock : MonoBehaviour
{

    public static ManagerLock INSTANCE;
    private Action action;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void acquire(Action action)
    {
        this.action = action;
    }

    public void release()
    {
        this.action();
    }

}
