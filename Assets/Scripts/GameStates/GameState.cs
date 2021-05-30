using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{

    public virtual void start()
    {
        Model.INSTANCE.StartCoroutine(startCoroutine());
    }

    public virtual IEnumerator startCoroutine()
    {
        yield break;
    }

    public void notifyTextOptionPressed(EText eText)
    {
        Logger.log("Text -> " + eText.text);
        ManagerText.INSTANCE.concealText();

        Model.INSTANCE.StartCoroutine(executeTextOptionCoroutine(eText));
        executeTextOption(eText);
    }

    protected virtual void executeTextOption(EText eText)
    {

    }

    protected virtual IEnumerator executeTextOptionCoroutine(EText eText)
    {
        yield break;
    }

    protected SpriteList getList(EList eList)
    {
        return ManagerSpriteList.INSTANCE.list[eList];
    }

    protected IEnumerator acquirePermit()
    {
        yield return new WaitWhile(() => ManagerAnimation.INSTANCE.isAnimatingSynchronous());
    }

}
