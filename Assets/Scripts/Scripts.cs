using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{

    public static Scripts INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

}
