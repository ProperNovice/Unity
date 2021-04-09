using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random
{

    private static string seed = DateTime.Now.Ticks.ToString();
    private static System.Random random = new System.Random(seed.GetHashCode());

    public static int Int(int start, int end)
    {
        return random.Next(start, end - start + 1);
    }

    public static bool ChanceOutcome(float chance)
    {
        float number = (float)random.NextDouble();
        return number * 100 <= chance;

    }

}
