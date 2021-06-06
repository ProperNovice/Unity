using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteList : MonoBehaviour, Interfaces.SaveLoadAble
{

    public static ManagerSpriteList INSTANCE;
    public GameObject spriteParent;
    public Dictionary<EList, SpriteList> list;

    public void Awake()
    {
        INSTANCE = this;
    }

    private void Start()
    {
        this.list = new Dictionary<EList, SpriteList>();

        foreach (EList eList in EList.list)
            this.list.Add(eList, new SpriteList());
    }

    public void loadStart()
    {
        foreach (SpriteList spriteList in this.list.Values)
            spriteList.arrayList.loadStart();
    }

    public void loadState()
    {
        foreach (SpriteList spriteList in this.list.Values)
            spriteList.arrayList.loadState();
    }

    public void saveStart()
    {
        foreach (SpriteList spriteList in this.list.Values)
            spriteList.arrayList.saveStart();
    }

    public void saveState()
    {
        foreach (SpriteList spriteList in this.list.Values)
            spriteList.arrayList.saveState();
    }
}
