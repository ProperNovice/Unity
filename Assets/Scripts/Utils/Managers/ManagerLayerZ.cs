using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLayerZ : MonoBehaviour
{

    public static ManagerLayerZ INSTANCE;
    public Dictionary<ELayerZ, ArrayList<GameObject>> list;

    private void Awake()
    {

        INSTANCE = this;

        this.list = new Dictionary<ELayerZ, ArrayList<GameObject>>();

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
            this.list.Add(eLayerZ, new ArrayList<GameObject>());

    }

    public void toFront(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addLast(gameObject);

        executeToFront();

    }

    public void toBack(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addFirst(gameObject);

        executeToFront();

    }

    public void executeToFront()
    {

        int sortingOrder = -1;

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
        {

            foreach (GameObject gameObject in this.list[eLayerZ])
            {
                SpriteView spriteView = gameObject.GetComponent<SpriteView>();
                spriteView.setSortingOrder(sortingOrder++);
            }

        }

    }

    private ArrayList<GameObject> getListContainingGameObject(GameObject gameObject)
    {

        foreach (ELayerZ eLayerZ in this.list.Keys)
            if (this.list[eLayerZ].contains(gameObject))
                return this.list[eLayerZ];

        ShutDown.execute(this);

        return new ArrayList<GameObject>();

    }

}
