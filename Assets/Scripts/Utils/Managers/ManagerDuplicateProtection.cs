using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDuplicateProtection : MonoBehaviour
{

    public static ManagerDuplicateProtection INSTANCE;
    public ArrayList<ArrayList<GameObject>> lists;
    private ArrayList<GameObject> gameObjects;
    public bool startDuplicateProtect;

    private void Awake()
    {
        INSTANCE = this;

        this.lists = new ArrayList<ArrayList<GameObject>>();
        this.gameObjects = new ArrayList<GameObject>();
        this.startDuplicateProtect = false;
    }

    void Update()
    {

        if (!this.startDuplicateProtect)
            return;

        this.startDuplicateProtect = false;
        this.gameObjects.clear();

        bool duplicateFound = false;

        foreach (ArrayList<GameObject> arraylist in this.lists)
        {

            foreach (GameObject gameObject in arraylist)
            {
                if (this.gameObjects.contains(gameObject))
                    duplicateFound = true;
                else
                    this.gameObjects.addLast(gameObject);
            }

        }

        if (duplicateFound)
        {
            Logger.log("duplicate found");
            ShutDown.execute(this);
        }
        else
            Logger.log("duplicate protected");

    }

}
