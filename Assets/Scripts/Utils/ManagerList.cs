using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    public GameObject parent;
    public Dictionary<EList, SpriteList> lists;

    public void Awake()
    {

        INSTANCE = this;
        this.lists = new Dictionary<EList, SpriteList>();

        foreach (EList eList in System.Enum.GetValues(typeof(EList)))
        {

            SpriteList spriteList = this.parent.AddComponent<SpriteList>();
            spriteList.list = eList;
            this.lists.Add(eList, spriteList);

        }

    }

}
