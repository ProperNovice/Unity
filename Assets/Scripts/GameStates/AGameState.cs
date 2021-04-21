using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameState
{

    public abstract void start();

    public void handleTextOptionPressed(EText eText)
    {

    }

    public void executeKeyPressed()
    {

    }

    protected void executeTextOption(EText eText)
    {

    }

    public void handleGameObjectPressed(GameObject gameObject)
    {

    }

}
