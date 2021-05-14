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
        this.gapBorders = new Vector2(25, 25);
        this.gapBetweenObjects = new Vector2(10, 10);
    }

}
