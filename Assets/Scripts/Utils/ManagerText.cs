using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerText : MonoBehaviour
{

    public GameObject text;
    public static ManagerText INSTANCE;
    private ArrayList<TextView> list;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new ArrayList<TextView>();

    }

    private void Start()
    {
        foreach (EText eText in EText.list())
        {

            GameObject gameObject = Instantiate(this.text);
            TextView textView = gameObject.GetComponent<TextView>();
            textView.setText(eText);

            this.list.addLast(textView);

        }

    }

}
