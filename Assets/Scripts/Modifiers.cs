using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{

    public static Modifiers INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

}
