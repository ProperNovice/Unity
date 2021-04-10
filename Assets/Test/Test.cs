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

        ShutDown.execute();

    }

    public class Li : IEnumerable
    {

        public List<A> l = new List<A>();

        public IEnumerator GetEnumerator()
        {
            return l.GetEnumerator();
        }

    }

    public class A
    {

        private int a;
        public A(int a)
        {
            this.a = a;
        }

        public void print()
        {
            Debug.Log(a);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
