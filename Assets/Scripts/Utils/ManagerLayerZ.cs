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

    private void executeToFront()
    {

        int x = 0;

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
        {

            foreach (GameObject gameObject in this.list[eLayerZ])
            {
                SpriteView spriteView = ManagerSpriteView.INSTANCE.list[gameObject];
                spriteView.setSortingOrder(x++);
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
