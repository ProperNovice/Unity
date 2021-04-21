using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolean : Interfaces.ISaveLoadAble
{

    private bool current, start, state;

    public Boolean(bool value)
    {
        this.current = value;
        this.start = this.current;
        this.state = this.current;
    }

    public void set(bool value)
    {
        this.current = value;
    }

    public bool get()
    {
        return this.current;
    }

    public void print()
    {
        Logger.log(getString());
    }

    public override string ToString()
    {
        return getString();
    }

    private string getString()
    {
        return "boolean -> " + this.current;
    }

    public void loadStart()
    {
        this.current = this.start;
    }

    public void loadState()
    {
        this.current = this.state;
    }

    public void saveStart()
    {
        this.start = this.current;
    }

    public void saveState()
    {
        this.state = this.current;
    }

}
