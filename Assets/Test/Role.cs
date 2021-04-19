using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Role
{
    public readonly static Role Engineer = new Role(0, "Engineer");
    public readonly static Role Scientist = new Role(1, "Scientist");
    public readonly static Role General = new Role(2, "General");
    public readonly static Role Diver = new Role(3, "Diver");

    public readonly string Name;
    public readonly int Value;

    private Role(int val, string name)
    {
        Value = val;
        Name = name;
    }

    public static IEnumerable<Role> List()
    {
        return new[] { Engineer, Scientist, General, Diver };
    }

    public static Role FromString(string roleString)
    {
        return List().Single(r => String.Equals(r.Name, roleString, StringComparison.OrdinalIgnoreCase));
    }

    public static Role FromValue(int value)
    {
        return List().Single(r => r.Value == value);
    }

}
