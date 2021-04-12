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
        // sv.setWidth(100);
        // sv.setHeight(400);

        Vector2 v2 = sv.getDimensions();

        sv.relocateTopLeft(0, v2.y);

        // ShutDown.execute("program ended");

    }


    // Update is called once per frame
    void Update()
    {

    }
}
