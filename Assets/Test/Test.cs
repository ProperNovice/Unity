using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

        GameObject go = Instantiate(this.prefab) as GameObject;
        go.transform.position = new Vector3(200, 200, 0);

        SpriteView sv = go.GetComponent<SpriteView>();

        sv.setFrontBack("f", "b");
        // sv.setFront("f");
        // sv.setBack("f");


    }

    // Update is called once per frame
    void Update()
    {

    }
}
