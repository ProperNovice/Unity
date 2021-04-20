using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    private Dictionary<SpriteView, SpriteView> select;

    private void Awake()
    {
        INSTANCE = this;
        this.select = new Dictionary<SpriteView, SpriteView>();
    }

    void Start()
    {
        
    }

}
