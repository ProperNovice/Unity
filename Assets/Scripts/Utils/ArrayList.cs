using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayList<T> : IEnumerable, Interfaces.ISaveLoadAble
{

    private List<T> list = new List<T>();
    private List<T> listState = new List<T>();
    private List<T> listStart = new List<T>();
    private int capacity = -1;

    public ArrayList()
    {

    }

    public ArrayList(int capacity)
    {
        this.capacity = capacity;
    }

    public ArrayList(T[] list)
    {
        foreach (T t in list)
            addLast(t);
    }

    public void addFirst(T t)
    {
        this.list.Insert(0, t);
    }

    public void addLast(T t)
    {
        this.list.Add(t);
    }

    public bool contains(T t)
    {
        return this.list.Contains(t);
    }

    public T getFirst()
    {
        return this.list[0];
    }

    public T getLast()
    {
        return this.list[this.list.Count - 1];
    }

    public T get(int index)
    {
        return this.list[index];
    }

    public void remove(T t)
    {
        this.list.Remove(t);
    }

    public T removeFirst()
    {

        T t = this.list[0];
        this.list.RemoveAt(0);
        return t;

    }

    public T removeLast()
    {

        int index = this.list.Count - 1;

        T t = this.list[index];
        remove(t);
        return t;

    }

    public T remove(int index)
    {
        T t = get(index);
        this.list.Remove(t);
        return t;
    }

    public T removeRandom()
    {

        int index = Random.Int(0, this.list.Count - 1);

        T t = get(index);
        remove(t);

        return t;

    }

    public int indexOf(T t)
    {
        return this.list.IndexOf(t);
    }

    public void clear()
    {
        this.list.Clear();
    }

    public void shuffle()
    {

        List<T> listTemp = new List<T>();

        while (list.Count != 0)
            listTemp.Add(removeRandom());

        this.list.AddRange(listTemp);

    }

    public void reverse()
    {
        this.list.Reverse();
    }

    public int size()
    {
        return this.list.Count;
    }

    public bool isEmpty()
    {
        return this.list.Count == 0;
    }

    public void setCapacity(int capacity)
    {
        this.capacity = capacity;
    }

    public bool isMaximumSize()
    {
        return this.list.Count == this.capacity;
    }

    public bool isOverSized()
    {
        if (this.capacity == -1)
            return false;
        else
            return this.list.Count > this.capacity;
    }

    public void addRange(ArrayList<T> list)
    {

        foreach (T t in list)
            addLast(t);

    }

    public void print()
    {

        Logger.log("printing list - start");

        foreach (T t in this.list)
            Logger.log(t);

        Logger.log("printing list - end");

    }

    public ArrayList<T> clone()
    {

        ArrayList<T> arrayList = new ArrayList<T>();

        foreach (T t in this.list)
            arrayList.addLast(t);

        return arrayList;

    }

    public IEnumerator GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public void saveState()
    {
        this.listState.Clear();
        this.listState.AddRange(this.list);
    }

    public void loadState()
    {
        this.list.Clear();
        this.list.AddRange(this.listState);
    }

    public void saveStart()
    {
        this.listStart.Clear();
        this.listStart.AddRange(this.list);
    }

    public void loadStart()
    {
        this.list.Clear();
        this.list.AddRange(this.listStart);
    }
}
