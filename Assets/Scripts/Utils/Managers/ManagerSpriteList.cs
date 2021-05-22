using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteList : MonoBehaviour, Interfaces.SaveLoadAble
{

    public static ManagerSpriteList INSTANCE;
    public GameObject spriteParent;
    public Dictionary<EList, SpriteList> list = new Dictionary<EList, SpriteList>();

    public void Awake()
    {
        INSTANCE = this;

        foreach (EList eList in System.Enum.GetValues(typeof(EList)))
            this.list.Add(eList, new SpriteList());
    }

    private void Start()
    {

    }

    public void loadStart()
    {

    }

    public void loadState()
    {

    }

    public void saveStart()
    {

    }

    public void saveState()
    {

    }
}
