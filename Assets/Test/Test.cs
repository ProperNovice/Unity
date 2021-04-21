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

        for (int counter = 1; counter <= 11; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("76", "b");
            //sv.setWidth(350);

            ManagerList.INSTANCE.lists[EList.DECK].arrayList.addLast(go);

        }

        ManagerList.INSTANCE.lists[EList.DECK].listCoordinates = new Vector2(1280, 720);
        ManagerList.INSTANCE.lists[EList.DECK].rearrangeType = Enums.RearrangeTypeEnum.PIVOT;
        ManagerList.INSTANCE.lists[EList.DECK].objectsPerRow = 6;

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
