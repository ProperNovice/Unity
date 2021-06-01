using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFlow : MonoBehaviour
{

    public static ManagerFlow INSTANCE;
    public ArrayList<GameState> list;
    public GameState gameStateCurrent;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new ArrayList<GameState>();
    }

    private void Start()
    {
        executeGameState(new StartGame());
    }

    public void proceed()
    {

        if (this.list.isEmpty())
        {
            Logger.log("flow is empty");
            this.gameStateCurrent = null;
            return;
        }

        this.gameStateCurrent = this.list.removeFirst();
        Logger.log("Gamestate -> " + this.gameStateCurrent);

        this.gameStateCurrent.start();

    }

    public void executeGameState(params GameState[] aGameState)
    {
        this.list.addFirst(aGameState);
        proceed();
    }

}
