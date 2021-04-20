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

        for (int counter = 1; counter <= 1; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("76", "b");

            Logger.log(sv.getDimensions());
            sv.setWidth(450);
            Logger.log(sv.getDimensions());

            ManagerList.INSTANCE.lists[EList.DECK].arrayList.addLast(go);

        }

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (ManagerAnimation.INSTANCE.isAnimating())
                return;

            ManagerList.INSTANCE.lists[EList.DECK].animateAsynchronous();

        }
        else if (Input.GetMouseButtonDown(1))
        {
            ManagerList.INSTANCE.lists[EList.DECK].relocateSprites();
        }

    }

}
