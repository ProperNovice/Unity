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

    protected virtual void executeTextOption(EText eText)
    {

    }

    protected SpriteList getList(EList eList)
    {
        return ManagerSpriteList.INSTANCE.lists[eList];
    }

}
