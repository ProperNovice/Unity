using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerText : MonoBehaviour
{

    public GameObject text;
    public Transform parent;
    public Vector2 coordinates;
    public Enums.RearrangeType rearrangeType = Enums.RearrangeType.LINEAR;
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

        foreach (EText eText in EText.list)
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

        relocateTexts();
    }

    private void relocateTexts()
    {

        float y = this.coordinates.y;

        if (this.rearrangeType.Equals(Enums.RearrangeType.PIVOT))
        {

            float totalY = 0;

            foreach (TextView textView in this.listShowing)
                totalY += textView.getDimensions().y;

            y += totalY / 2;

        }

        foreach (TextView textView in this.listShowing)
        {
            textView.relocate(this.coordinates.x, y);
            textView.setActive(true);

            y -= textView.getDimensions().y;
        }

    }

    public void concealText()
    {

        while (!this.listShowing.isEmpty())
        {

            TextView textView = this.listShowing.removeFirst();
            textView.setActive(false);

        }

    }

    public void handleKeyCodeID(int keyCodeID)
    {

        int textOption = 0;

        foreach (TextView textView in this.listShowing)
        {

            EText eText = textView.eText;

            if (!eText.isTextOption)
                continue;

            textOption++;

            if (textOption != keyCodeID)
                continue;

            ManagerFlow.INSTANCE.gameStateCurrent.notifyTextOptionPressed(eText);
            return;

        }

    }

}
