using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    public SpriteList deck;

    private void Awake()
    {
        if (INSTANCE != null)
            return;

        INSTANCE = this;
    }

    private void Start()
    {
        this.deck.test();
    }

}
