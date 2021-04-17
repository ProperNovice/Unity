using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    public Dictionary<EList, SpriteList> lists;

    public void Awake()
    {

        INSTANCE = this;
        this.lists = new Dictionary<EList, SpriteList>();

    }

}
