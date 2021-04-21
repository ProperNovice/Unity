using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFlow : MonoBehaviour
{


    public static ManagerFlow INSTANCE;
    public ArrayList<AGameState> flow;
    public AGameState gameStateCurrent;

    private void Awake()
    {
        INSTANCE = this;
        this.flow = new ArrayList<AGameState>();
    }

    public void proceed()
    {

        this.gameStateCurrent = this.flow.removeFirst();

        Logger.log("executing gamestate");
        Logger.log(this.gameStateCurrent);

        this.gameStateCurrent.start();

    }

    public void executeGameState(AGameState aGameState)
    {
        this.flow.addFirst(aGameState);
        proceed();
    }

}
