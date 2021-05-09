using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteList : MonoBehaviour
{

    public static ManagerSpriteList INSTANCE;

    public void Awake()
    {
        INSTANCE = this;
    }

}
