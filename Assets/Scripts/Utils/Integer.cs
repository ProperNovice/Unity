using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integer : Interfaces.SaveLoadAble
{

    private int current, start, state;

    public Integer() : this(0)
    {

    }

    public Integer(int number)
    {
        this.current = number;
        this.start = this.current;
        this.state = this.current;
    }

    public void set(int number)
    {
        this.current = number;
    }

    public void add(int number)
    {
        this.current += number;
    }

    public void substract(int number)
    {
        this.current -= number;
    }

    public void setRandom(int firstNumber, int secondNumber)
    {
        this.current = Random.Int(firstNumber, secondNumber);
    }

    public int get()
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
        return "integer -> " + this.current;
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
