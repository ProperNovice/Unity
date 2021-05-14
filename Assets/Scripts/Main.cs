using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    private Vector2 screenResolution;

    void Start()
    {
        this.screenResolution = new Vector2(Screen.width, Screen.height);
    }

}
