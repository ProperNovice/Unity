using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAnimation : MonoBehaviour
{

    public static ManagerAnimation INSTANCE;

    private void Awake()
    {

        if (INSTANCE != null)
            return;

        INSTANCE = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
