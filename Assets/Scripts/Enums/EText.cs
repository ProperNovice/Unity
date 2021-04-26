using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using UnityEngine;

public class EText
{

    public static ArrayList<EText> list = new ArrayList<EText>();
    public static EText START = new EText("Start", true);
    public static EText CONTINUE = new EText("Continue", true);

    public readonly string text;
    public readonly bool isTextOption;

    private EText(string text, bool isTextOption)
    {
        this.text = text;
        this.isTextOption = isTextOption;
        list.addLast(this);
    }

    public void show()
    {
        ManagerText.INSTANCE.showText(this);
    }

}
