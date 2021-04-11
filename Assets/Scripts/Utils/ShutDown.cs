using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown
{

    public static void execute()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public static void execute(string log)
    {
        Logger.log(log);
        execute();
    }

}
