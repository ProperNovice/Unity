using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFlow : MonoBehaviour
{


    public static ManagerFlow INSTANCE;
    public ArrayList<AGameState> list;
    public AGameState gameStateCurrent;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new ArrayList<AGameState>();
    }

    public void proceed()
    {

        this.gameStateCurrent = this.list.removeFirst();
        Logger.log("executing gamestate -> " + this.gameStateCurrent);
        this.gameStateCurrent.start();

    }

    public void executeGameState(AGameState aGameState)
    {
        this.list.addFirst(aGameState);
        proceed();
    }

}
