using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject sprite;
    private ArrayList<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {

        this.list = new ArrayList<GameObject>();

        for (int counter = 1; counter <= 10; counter++)
        {

            GameObject go = Instantiate(this.sprite);
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("76", "b");

            ManagerList.INSTANCE.lists[EList.DECK].arrayList.addLast(go);
            this.list.addLast(go);

        }

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("yay");
            ManagerList.INSTANCE.lists[EList.DECK].animateAsynchronous();

        }

    }

}
