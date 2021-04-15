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

        for (int counter = 1; counter <= 4; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("87", "b");

            ManagerList.INSTANCE.lists.getValue(EList.DECK).arrayList.addLast(go);

        }

        // ManagerList.INSTANCE.lists.getValue(EList.DECK).animateAsynchronous();

        // ShutDown.execute("program ended");

    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        ManagerList.INSTANCE.lists.getValue(EList.DECK).animateAsynchronous();
    }

}
