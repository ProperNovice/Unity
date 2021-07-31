using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{

    public static Modifiers INSTANCE;
    public Vector2 gapBorders, gapBetweenSprites;

    private void Awake()
    {
        INSTANCE = this;
    }

}
