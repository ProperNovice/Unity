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

        go.transform.localScale = new Vector2(1.5f, 1.5f);

        sv.a();

        sv.relocateCenter(0, 0);
        sv.relocateTopLeft(0, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
