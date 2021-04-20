using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using UnityEngine;

public class EText
{


    public static ArrayList<EText> arrayList = new ArrayList<EText>();
    public static EText start = new EText("Start", true);
    public static EText cont = new EText("Continue", true);

    public readonly string text;
    public readonly bool isTextOption;

    private EText(string text, bool isTextOption)
    {
        this.text = text;
        this.isTextOption = isTextOption;
        arrayList.addLast(this);
    }

    public void show()
    {
        ManagerText.INSTANCE.showText(this);
    }

}
