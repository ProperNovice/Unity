using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteList : MonoBehaviour, Interfaces.SaveLoadAble
{

    public static ManagerSpriteList INSTANCE;
    public GameObject spriteParent;
    public ArrayList<SpriteList> lists;

    public void Awake()
    {
        INSTANCE = this;
        this.lists = new ArrayList<SpriteList>();
    }

    private void Start()
    {

    }

    public void loadStart()
    {
        foreach (SpriteList spriteList in this.lists)
            spriteList.arrayList.loadStart();
    }

    public void loadState()
    {
        foreach (SpriteList spriteList in this.lists)
            spriteList.arrayList.loadState();
    }

    public void saveStart()
    {
        foreach (SpriteList spriteList in this.lists)
            spriteList.arrayList.saveStart();
    }

    public void saveState()
    {
        foreach (SpriteList spriteList in this.lists)
            spriteList.arrayList.saveState();
    }
}
