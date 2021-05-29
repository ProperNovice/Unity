using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{

    public static Scripts INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    private SpriteList getList(EList eList)
    {
        return ManagerSpriteList.INSTANCE.list[eList];
    }

    private IEnumerator acquirePermit()
    {
        yield return new WaitWhile(() => ManagerAnimation.INSTANCE.isAnimatingSynchronous());
    }

}
