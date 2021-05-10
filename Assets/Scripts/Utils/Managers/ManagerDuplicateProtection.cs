using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDuplicateProtection : MonoBehaviour
{

    public static ManagerDuplicateProtection INSTANCE;
    public ArrayList<ArrayList<GameObject>> lists;
    private ArrayList<GameObject> gameObjects;

    private void Awake()
    {
        INSTANCE = this;

        this.lists = new ArrayList<ArrayList<GameObject>>();
        this.gameObjects = new ArrayList<GameObject>();
    }

    void Update()
    {

        this.gameObjects.clear();

        foreach (ArrayList<GameObject> arraylist in this.lists)
        {

            foreach (GameObject gameObject in arraylist)
            {

                if (this.gameObjects.contains(gameObject))
                    ShutDown.execute(this);
                else
                    this.gameObjects.addLast(gameObject);

            }

        }

    }

}
