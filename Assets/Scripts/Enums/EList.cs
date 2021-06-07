using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EList : Interfaces.SaveLoadAble
{

    private static ArrayList<SpriteList> lists = new ArrayList<SpriteList>();

    public SpriteList list = null;

    private EList()
    {
        this.list = new SpriteList();
        lists.addLast(this.list);
    }

    public void loadStart()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.loadStart();
    }

    public void loadState()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.loadState();
    }

    public void saveStart()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.saveStart();
    }

    public void saveState()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.saveState();
    }
}
