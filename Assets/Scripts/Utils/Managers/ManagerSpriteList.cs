using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteList : MonoBehaviour
{

    public static ManagerSpriteList INSTANCE;
    public GameObject parent;
    public Dictionary<EList, SpriteList> lists;

    public void Awake()
    {

        INSTANCE = this;
        this.lists = new Dictionary<EList, SpriteList>();

        foreach (EList eList in System.Enum.GetValues(typeof(EList)))
        {

            SpriteList spriteList = this.parent.AddComponent<SpriteList>();
            spriteList.eList = eList;
            this.lists.Add(eList, spriteList);

        }

    }

}
