using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger
{

    public static void log(object log)
    {
        Debug.Log(log);
    }

    public static void log()
    {
        Debug.Log("");
    }


}
