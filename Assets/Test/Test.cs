using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {

        for (int counter = 1; counter <= 10; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("f", "b");

            ManagerList.INSTANCE.lists.getValue(EList.DECK).arrayList.addLast(go);

        }

        ManagerList.INSTANCE.lists.getValue(EList.DECK).animateAsynchronous();

        // ShutDown.execute("program ended");

    }



    // Update is called once per frame
    void Update()
    {

    }
}
