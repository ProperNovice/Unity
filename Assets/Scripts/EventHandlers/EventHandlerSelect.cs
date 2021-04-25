using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerSelect : EventHandler
{

    private void Awake()
    {

    }

    public override void OnMouseDown()
    {
        getEventHandler().OnMouseDown();
    }

    public override void OnMouseEnter()
    {
        getEventHandler().OnMouseEnter();
    }

    public override void OnMouseExit()
    {
        getEventHandler().OnMouseExit();
    }

    private EventHandler getEventHandler()
    {
        GameObject gameObject = ManagerSpriteSelect.INSTANCE.getGameObjectKey(this.gameObject);
        EventHandler eventHandler = ManagerEventHandler.INSTANCE.list[gameObject];
        return eventHandler;
    }

}
