using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashmap<K, V>
{

    private ArrayList<K> keys = new ArrayList<K>();
    private ArrayList<V> values = new ArrayList<V>();

    public Hashmap()
    {

    }

    public void put(K key, V value)
    {
        this.keys.addLast(key);
        this.values.addLast(value);
    }

}
