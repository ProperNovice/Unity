using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayList : MonoBehaviour
{

    private List<GameObject> list = new List<GameObject>();
    private List<GameObject> listState = new List<GameObject>();
    private List<GameObject> listStart = new List<GameObject>();
    public int maximumSize = -1;


    public void addFirst(GameObject gameObject)
    {
        this.list.Insert(0, gameObject);
    }

    public void addLast(GameObject gameObject)
    {
        this.list.Add(gameObject);
    }

    public bool contains(GameObject gameObject)
    {
        return this.list.Contains(gameObject);
    }

    public GameObject getFirst()
    {
        return this.list[0];
    }

    public GameObject getLast()
    {
        return this.list[this.list.Count - 1];
    }

    public GameObject get(int index)
    {
        return this.list[index];
    }

    public void remove(GameObject gameObject)
    {
        this.list.Remove(gameObject);
    }

    public GameObject removeFirst()
    {

        GameObject gameObject = this.list[0];
        this.list.RemoveAt(0);
        return gameObject;

    }

    public GameObject removeLast()
    {

        int index = this.list.Count - 1;

        GameObject gameObject = this.list[index];
        this.list.Remove(gameObject);
        return gameObject;

    }

    public GameObject removeRandom()
    {

        int index = Random.Int(0, this.list.Count - 1);

        GameObject gameObject = get(index);
        this.list.Remove(gameObject);

        return gameObject;

    }

    public void clear()
    {
        this.list.Clear();
    }

    public void shuffle()
    {

        List<GameObject> listTemp = new List<GameObject>();

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

}
