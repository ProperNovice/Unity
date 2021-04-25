using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventHandler : MonoBehaviour
{

    private void Awake()
    {
        ManagerEventHandler.INSTANCE.list.Add(this.gameObject, this);
    }

    public virtual void OnMouseDown()
    {

    }

    public virtual void OnMouseEnter()
    {

    }

    public virtual void OnMouseExit()
    {

    }

}
