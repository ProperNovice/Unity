using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown
{

    public static void execute()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public static void execute(string log)
    {
        Logger.log(log);
        execute();
    }

}
