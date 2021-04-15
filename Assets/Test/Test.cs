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

        check(this.sprite);

        for (int counter = 1; counter <= 4; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("87", "b");

            check(go);

            ManagerList.INSTANCE.lists.getValue(EList.DECK).arrayList.addLast(go);

        }

        // ManagerList.INSTANCE.lists.getValue(EList.DECK).animateAsynchronous();
        ManagerList.INSTANCE.lists.getValue(EList.DECK).relocateSprites();

        // ShutDown.execute("program ended");

    }

    private void check(GameObject gameObject)
    {

    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        ManagerList.INSTANCE.lists.getValue(EList.DECK).animateAsynchronous();

    }

}
