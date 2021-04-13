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

        for (int counter = 1; counter <= 10; counter++)
        {

            GameObject go = Instantiate(this.prefab) as GameObject;
            SpriteView sv = go.GetComponent<SpriteView>();

            sv.setFrontBack("f", "b");

        }

        ManagerList.INSTANCE.deck.coordinatesList = new Vector2(400, 400);

        // ShutDown.execute("program ended");

    }



    // Update is called once per frame
    void Update()
    {

    }
}
