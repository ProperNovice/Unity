using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerList : MonoBehaviour
{

    public static ManagerList INSTANCE;
    private Hashmap<EList, SpriteList> spriteLists = new Hashmap<EList, SpriteList>();

    private void Awake()
    {
        if (INSTANCE != null)
            return;

        INSTANCE = this;
    }

    public SpriteList getList(EList eList)
    {
        return this.spriteLists.getValue(eList);
    }

    public void addList(EList eList, SpriteList spriteList)
    {
        this.spriteLists.put(eList, spriteList);
    }

}
