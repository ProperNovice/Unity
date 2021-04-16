using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLayerZ : MonoBehaviour
{

    public static ManagerLayerZ INSTANCE;
    public Hashmap<ELayerZ, ArrayList<GameObject>> list;

    private void Awake()
    {

        INSTANCE = this;

        this.list = new Hashmap<ELayerZ, ArrayList<GameObject>>();

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
            this.list.put(eLayerZ, new ArrayList<GameObject>());

    }

    public void toFront(GameObject gameObject)
    {

    }

    public void toBack(GameObject gameObject)
    {

    }

    private ArrayList<GameObject> getListContainingGameObject(GameObject gameObject)
    {

        foreach (ELayerZ eLayerZ in this.list)
            if (this.list.getValue(eLayerZ).contains(gameObject))
                return this.list.getValue(eLayerZ);

        ShutDown.execute(this);

        return new ArrayList<GameObject>();

    }

}
