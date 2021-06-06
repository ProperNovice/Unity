using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EList
{

    public static ArrayList<EList> list = new ArrayList<EList>();

    private EList()
    {
        list.addLast(this);
    }

    public SpriteList get()
    {
        return ManagerSpriteList.INSTANCE.list[this];
    }

}
