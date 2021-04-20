using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerText : MonoBehaviour
{

    public float x, y;
    public GameObject text;
    public Transform parent;
    public static ManagerText INSTANCE;
    private ArrayList<TextView> listComplete, listShowing;
    private Dictionary<EText, TextView> dictionary;

    private void Awake()
    {
        INSTANCE = this;

        this.listComplete = new ArrayList<TextView>();
        this.listShowing = new ArrayList<TextView>();
        this.dictionary = new Dictionary<EText, TextView>();
    }

    private void Start()
    {

        foreach (EText eText in EText.arrayList)
        {

            GameObject gameObject = Instantiate(this.text);
            TextView textView = gameObject.GetComponent<TextView>();
            textView.setText(eText);
            textView.setActive(false);

            gameObject.transform.parent = this.parent;

            this.listComplete.addLast(textView);
            this.dictionary.Add(eText, textView);

        }

    }

    public void showText(EText eText)
    {

        TextView textView = this.dictionary[eText];

        if (this.listShowing.contains(textView))
            ShutDown.execute("EText is already active");

        this.listShowing.addLast(this.dictionary[eText]);

        float y = this.y - 50 * this.listShowing.size();


        textView.relocate(this.x, y);
        textView.setActive(true);

    }

    public void concealText()
    {

        while (!this.listShowing.isEmpty())
        {

            TextView textView = this.listShowing.removeFirst();
            textView.setActive(false);

        }

    }

}
