using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject pivot, prefab;

    // Start is called before the first frame update
    void Start()
    {

        GameObject go = Instantiate(this.prefab) as GameObject;
        go.transform.parent = this.pivot.transform;

        SpriteView sv = go.GetComponent<SpriteView>();

        sv.setFrontBack("f", "b");
        sv.relocateTopLeft(0, 353);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
