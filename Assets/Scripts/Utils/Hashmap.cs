using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashmap<K, V> : IEnumerable
{

    private ArrayList<K> keys = new ArrayList<K>();
    private ArrayList<V> values = new ArrayList<V>();

    public Hashmap()
    {

    }

    public void put(K key, V value)
    {
        if (this.keys.contains(key))
            ShutDown.execute("duplicate key in hashmap");

        this.keys.addLast(key);
        this.values.addLast(value);
    }

    public void remove(K key)
    {

        if (!this.keys.contains(key))
            ShutDown.execute("key doesn't exist");

        int index = this.keys.indexOf(key);

        this.keys.remove(index);
        this.values.remove(index);

    }

    public V getValue(K key)
    {
        int index = this.keys.indexOf(key);
        return this.values.get(index);
    }

    public void print()
    {

        Logger.log("printing map - start");

        for (int counter = 0; counter < this.keys.size(); counter++)
            Logger.log("Key: " + this.keys.get(counter) + " -> Value: " + this.values.get(counter));

        Logger.log("printing map - end");

    }

    public IEnumerator GetEnumerator()
    {
        return this.keys.GetEnumerator();
    }

}
