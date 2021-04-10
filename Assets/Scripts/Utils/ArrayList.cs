using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayList<T> : IEnumerable
{

    private List<T> list = new List<T>();
    private List<T> listState = new List<T>();
    private List<T> listStart = new List<T>();
    private int maximumSize = -1;

    public ArrayList()
    {

    }

    public ArrayList(int maximumSize)
    {
        this.maximumSize = maximumSize;
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

    public T removeRandom()
    {

        int index = Random.Int(0, this.list.Count - 1);

        T t = get(index);
        remove(t);

        return t;

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

    public int count()
    {
        return this.list.Count;
    }

    public bool isEmpty()
    {
        return this.list.Count == 0;
    }

    public bool isMaximumSize()
    {
        return this.list.Count == this.maximumSize;
    }

    public bool isOverSized()
    {
        return this.list.Count > this.maximumSize;
    }

    public void addRange(ArrayList<T> list)
    {

        foreach (T t in list)
            addLast(t);

    }

    public IEnumerator GetEnumerator()
    {
        return this.list.GetEnumerator();
    }
}
