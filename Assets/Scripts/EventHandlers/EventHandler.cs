using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventHandler : MonoBehaviour
{

    public void OnMouseDown()
    {
        if (!ManagerAnimation.INSTANCE.isAnimatingSynchronous())
            primary();
    }

    public void OnMouseEnter()
    {
        if (!ManagerAnimation.INSTANCE.isAnimatingSynchronous())
            enter();
    }

    public void OnMouseExit()
    {
        if (!ManagerAnimation.INSTANCE.isAnimatingSynchronous())
            exit();
    }

    protected virtual void primary()
    {

    }

    protected virtual void enter()
    {

    }

    protected virtual void exit()
    {

    }

}
