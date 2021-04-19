using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;
using UnityEngine;

public class EText
{

    public static EText start = new EText("Start", true);
    public static EText cont = new EText("Continue", true);
    public static EText helloya = new EText("Helloya", false);

    public readonly string text;
    public readonly bool isTextOption;

    private EText(string text, bool isTextOption)
    {
        this.text = text;
        this.isTextOption = isTextOption;
    }

    public static IEnumerable<EText> list()
    {
        return new[] { start, cont, helloya };
    }

    public void show()
    {
        ManagerText.INSTANCE.showText(this);
    }

}
