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

        this.gameStateCurrent = this.list.removeFirst();
        Logger.log("executing gamestate -> " + this.gameStateCurrent);
        this.gameStateCurrent.start();

    }

    public void executeGameState(GameState aGameState)
    {
        this.list.addFirst(aGameState);
        proceed();
    }

}
