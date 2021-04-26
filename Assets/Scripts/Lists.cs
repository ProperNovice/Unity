using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{

    public static Lists INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

}
