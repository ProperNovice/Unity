using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown : MonoBehaviour
{

    public static void execute()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
