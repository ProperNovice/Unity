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

        SpriteView sv = go.GetComponent<SpriteView>();

        sv.setFrontBack("f", "b");
        sv.relocateTopLeft(0, 353);

        List<A> list = new List<A>((A[])System.Enum.GetValues(typeof(A)));
        ArrayList<A> arrayList = new ArrayList<A>((A[])System.Enum.GetValues(typeof(A)));

        arrayList.shuffle();

        foreach (A aq in arrayList)
            Debug.Log(aq);

        // ShutDown.execute();

    }

    public enum A
    {
        Q, W, E, R

    }

    // Update is called once per frame
    void Update()
    {

    }
}
