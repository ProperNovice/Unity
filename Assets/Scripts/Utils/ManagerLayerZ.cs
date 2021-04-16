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

}
