using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{

    public static Modifiers INSTANCE;
    public Vector2 gapBorders, gapBetweenObjects;

    private void Awake()
    {
        INSTANCE = this;
    }

}
