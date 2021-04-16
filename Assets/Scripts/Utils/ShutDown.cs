using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown
{

    public static void execute()
    {

#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

    public static void execute(string log)
    {
        Logger.log(log);
        execute();
    }

    public static void execute(MonoBehaviour monoBehaviour)
    {
        Logger.log(monoBehaviour);
        execute();
    }

    public static void execute(MonoBehaviour monoBehaviour, string log)
    {
        Logger.log(monoBehaviour);
        Logger.log(log);
        execute();
    }

}
