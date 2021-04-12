using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    public SpriteList deck = new SpriteList();

    private void Awake()
    {
        if (INSTANCE != null)
            return;

        INSTANCE = this;
    }

}
