using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteView : MonoBehaviour
{

    public static ManagerSpriteView INSTANCE;
    public Dictionary<GameObject, SpriteView> list;
    public GameObject parent;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<GameObject, SpriteView>();
    }

}
