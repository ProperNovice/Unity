using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : AGameState
{
    public override void start()
    {

    }

    public override void executeTextOption(EText eText)
    {

        Logger.log("I am here");

        if (eText.Equals(EText.start))
            Logger.log("start re");

    }

}
