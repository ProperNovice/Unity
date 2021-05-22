using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlerSelect : EventHandler
{

    protected override void primary()
    {
        getEventHandler().OnMouseDown();
    }

    protected override void enter()
    {
        getEventHandler().OnMouseEnter();
    }

    protected override void exit()
    {
        getEventHandler().OnMouseExit();
    }

    private EventHandler getEventHandler()
    {
        GameObject gameObject = ManagerSpriteSelect.INSTANCE.getGameObjectKey(this.gameObject);
        EventHandler eventHandler = gameObject.GetComponent<EventHandler>();
        return eventHandler;
    }

}
