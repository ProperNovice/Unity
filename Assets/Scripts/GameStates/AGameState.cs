using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameState
{

    public abstract void start();

    public void notifyTextOptionPressed(EText eText)
    {
        ManagerText.INSTANCE.concealText();
        executeTextOption(eText);
    }

    public virtual void executeTextOption(EText eText)
    {

    }

    public void handleGameObjectPressed(GameObject gameObject)
    {

    }

}
