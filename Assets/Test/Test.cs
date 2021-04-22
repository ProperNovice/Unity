using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    public GameObject sprite;
    public GameObject go;

    void Start()
    {

        for (int counter = 1; counter <= 11; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("76", "b");
            //sv.setWidth(350);

            ManagerSpriteList.INSTANCE.lists[EList.DECK].arrayList.addLast(go);

            this.go = go;

        }

        ManagerSpriteList.INSTANCE.lists[EList.DECK].listCoordinates = new Vector2(1280, 720);
        ManagerSpriteList.INSTANCE.lists[EList.DECK].rearrangeType = Enums.RearrangeTypeEnum.PIVOT;
        ManagerSpriteList.INSTANCE.lists[EList.DECK].objectsPerRow = 6;

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (ManagerAnimation.INSTANCE.isAnimating())
                return;

            ManagerSpriteList.INSTANCE.lists[EList.DISCARD_PILE].arrayList.addLast(go);
            Logger.log("done");

        }
        else if (Input.GetMouseButtonDown(1))
        {
            ManagerSpriteList.INSTANCE.lists[EList.DECK].relocateSprites();
        }

    }

}
