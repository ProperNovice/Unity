using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{

    public static Modifiers INSTANCE;
    public Vector2 gapBetweenObjects;

    private void Awake()
    {
        INSTANCE = this;
        this.gapBetweenObjects = new Vector2(10, 10);
    }

}
