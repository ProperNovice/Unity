using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

        GameObject go = Instantiate(this.prefab) as GameObject;

        SpriteView sv = go.GetComponent<SpriteView>();

        sv.setFrontBack("f", "b");

        BoxCollider2D bc = go.GetComponent<BoxCollider2D>();
        Vector2 v2 = bc.size;

        sv.relocateTopLeft(0, v2.y);

        //ShutDown.execute("fluffy");

    }

    public enum Letters
    {
        A, B, C, D
    }

    // Update is called once per frame
    void Update()
    {

    }
}
