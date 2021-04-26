using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDuplicateProtection : MonoBehaviour
{

    public Dictionary<EList, ArrayList<GameObject>> lists;
    private ArrayList<GameObject> gameObjectsChecking;

    private void Awake()
    {
        this.lists = new Dictionary<EList, ArrayList<GameObject>>();
        this.gameObjectsChecking = new ArrayList<GameObject>();
    }

    void Start()
    {

        foreach (EList eList in ManagerSpriteList.INSTANCE.lists.Keys)
            this.lists.Add(eList, ManagerSpriteList.INSTANCE.lists[eList].arrayList);

    }


    void Update()
    {

        this.gameObjectsChecking.clear();

        foreach (EList eList in this.lists.Keys)
        {

            ArrayList<GameObject> gameObjectsToCheck = this.lists[eList].clone();

            while (!gameObjectsToCheck.isEmpty())
            {

                GameObject go = gameObjectsToCheck.removeFirst();

                if (this.gameObjectsChecking.contains(go))
                    handleDuplicateFound(go);
                else
                    this.gameObjectsChecking.addLast(go);

            }

        }

    }

    private void handleDuplicateFound(GameObject gameObject)
    {

        bool isFirstList = true;

        string msg = "duplicate list entry found -> ";

        foreach (EList eList in this.lists.Keys)
            if (this.lists[eList].contains(gameObject))
            {

                if (!isFirstList)
                    msg += " , ";

                isFirstList = false;
                msg += eList;

            }

        ShutDown.execute(msg);

    }

}
