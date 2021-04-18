using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{

    public GameObject sprite;
    public Dictionary<int, string> dictionary;
    public List<EListO> list;
    public List<int> i;

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

    [System.Serializable]
    public class EListO
    {
        public EList eList;
        public int number;
        public string text;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (ManagerAnimation.INSTANCE.isAnimating())
                return;

            ManagerList.INSTANCE.lists[EList.DECK].animateAsynchronous();

        }

    }

}
