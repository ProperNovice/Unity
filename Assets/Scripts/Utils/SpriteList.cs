using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteList : ScriptableObject, IEnumerable
{

    [SerializeField] private Enums.RelocatePositionEnum relocatePosition = Enums.RelocatePositionEnum.TOP_LEFT;
    [SerializeField] private ListCredentials listCredentials;
    [SerializeField] private ArrayList<GameObject> arrayList;

    public void animateAsynchronous()
    {

    }

    public void animateSynchronous()
    {

    }

    public void animateSynchronousLock()
    {

    }

    public void relocateSprites()
    {

    }

    public void relocateList(Vector2 vector2)
    {
        this.listCredentials.coordinatesList = vector2;
    }

    private void executeAction()
    {

    }

    public ArrayList<GameObject> getArrayList()
    {
        return this.arrayList;
    }

    public IEnumerator GetEnumerator()
    {
        return this.arrayList.GetEnumerator();
    }
}
