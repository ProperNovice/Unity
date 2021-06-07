using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerParents : MonoBehaviour
{

    public static ManagerParents INSTANCE;
    public GameObject parentSprite, parentText;

    private void Awake()
    {
        INSTANCE = this;
    }

}
