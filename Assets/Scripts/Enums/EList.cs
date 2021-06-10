using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EList
{

    private static ArrayList<SpriteList> lists = new ArrayList<SpriteList>();

    public SpriteList list = null;

    private EList()
    {
        this.list = new SpriteList();
        lists.addLast(this.list);
    }

    public static void loadStart()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.loadStart();
    }

    public static void loadState()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.loadState();
    }

    public static void saveStart()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.saveStart();
    }

    public static void saveState()
    {
        foreach (SpriteList spriteList in lists)
            spriteList.arrayList.saveState();
    }
}
