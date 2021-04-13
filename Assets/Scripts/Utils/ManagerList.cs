using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    public SpriteList deck;

    public void Awake()
    {

        if (INSTANCE != null)
            return;

        INSTANCE = this;

    }

    private void Start()
    {

    }

}
