using System.Collections;
using UnityEngine;

public class ArraySpriteList<T> : ArrayList<T>
{
    public override void addFirst(T t)
    {
        startDuplicateProtection();
        base.addFirst(t);
    }

    public override void addFirst(ArrayList<T> list)
    {
        startDuplicateProtection();
        base.addFirst(list);
    }

    public override void addFirst(params T[] list)
    {
        startDuplicateProtection();
        base.addFirst(list);
    }

    public override void addLast(T t)
    {
        startDuplicateProtection();
        base.addLast(t);
    }

    public override void addLast(ArrayList<T> list)
    {
        startDuplicateProtection();
        base.addLast(list);
    }

    public override void addLast(params T[] list)
    {
        startDuplicateProtection();
        base.addLast(list);
    }

    public override void clear()
    {
        startDuplicateProtection();
        base.clear();
    }

    public override void loadStart()
    {
        startDuplicateProtection();
        base.loadStart();
    }

    public override void loadState()
    {
        startDuplicateProtection();
        base.loadState();
    }

    public override T remove(T t)
    {
        startDuplicateProtection();
        return base.remove(t);
    }

    public override T remove(int index)
    {
        startDuplicateProtection();
        return base.remove(index);
    }

    public override ArrayList<T> removeAll()
    {
        startDuplicateProtection();
        return base.removeAll();
    }

    public override T removeFirst()
    {
        startDuplicateProtection();
        return base.removeFirst();
    }

    public override T removeLast()
    {
        startDuplicateProtection();
        return base.removeLast();
    }

    public override T removeRandom()
    {
        startDuplicateProtection();
        return base.removeRandom();
    }

    private void startDuplicateProtection()
    {
        ManagerDuplicateProtection.INSTANCE.startDuplicateProtect = true;
    }

}