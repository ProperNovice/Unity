using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{

    public static Model INSTANCE;

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
