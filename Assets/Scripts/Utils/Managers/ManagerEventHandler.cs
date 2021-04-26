using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEventHandler : MonoBehaviour
{

    public static ManagerEventHandler INSTANCE;
    public Dictionary<GameObject, EventHandler> list = new Dictionary<GameObject, EventHandler>();

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<GameObject, EventHandler>();
    }

}
