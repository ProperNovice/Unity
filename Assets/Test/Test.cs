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

            sv.setFrontBack("76", "b");

            ManagerList.INSTANCE.lists[EList.DECK].arrayList.addLast(go);

        }

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (ManagerAnimation.INSTANCE.isAnimating())
                return;

            // ManagerList.INSTANCE.lists[EList.DECK].animateAsynchronous();

        }

    }

}
