using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{

    public abstract void start();

    public void notifyTextOptionPressed(EText eText)
    {
        Logger.log("Text -> " + eText.text);
        ManagerText.INSTANCE.concealText();
        executeTextOption(eText);
    }

    public virtual void executeTextOption(EText eText)
    {

    }

    public void handleGameObjectPressed(GameObject gameObject)
    {

    }

    protected SpriteList getList(EList eList)
    {
        return ManagerSpriteList.INSTANCE.lists[eList];
    }

}
