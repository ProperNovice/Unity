using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteList : MonoBehaviour
{

    [SerializeField] private EList eList;
    [SerializeField] private Coordinates coordinates;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        ManagerList.INSTANCE.addList(this.eList, this);
    }

    public void print()
    {
        Logger.log(this.eList);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
