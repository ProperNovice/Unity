using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManagerAnimation : MonoBehaviour
{

    public static ManagerAnimation INSTANCE;
    [SerializeField] private float speed = 1200;
    [SerializeField] private ArrayList<AnimateAction> listSynchronous, listAsynchronous;

    private void Awake()
    {

        INSTANCE = this;

        this.listSynchronous = new ArrayList<AnimateAction>();
        this.listAsynchronous = new ArrayList<AnimateAction>();

    }

    void LateUpdate()
    {

        if (!this.listSynchronous.isEmpty())
            animateListSynchronous();

        if (!this.listAsynchronous.isEmpty())
            animateListAsynchronous();

    }

    private void animateListSynchronous()
    {
        animateExecute(this.listSynchronous);

        if (!this.listSynchronous.isEmpty())
            return;

        ManagerLock.INSTANCE.release();

    }

    private void animateListAsynchronous()
    {
        animateExecute(this.listAsynchronous);
    }

    private void animateExecute(ArrayList<AnimateAction> arrayList)
    {

        foreach (AnimateAction animateAction in arrayList.clone())
        {

            animateAction.animate();

            if (animateAction.isAnimating())
                continue;

            arrayList.remove(animateAction);

        }

    }
    public void animate(SpriteView spriteView, Vector2 coordinates, Enums.AnimateSynchEnum animateSynchEnum)
    {

        ArrayList<AnimateAction> list = new ArrayList<AnimateAction>();

        switch (animateSynchEnum)
        {
            case Enums.AnimateSynchEnum.SYNCHRONOUS:
                list = this.listSynchronous;
                break;

            case Enums.AnimateSynchEnum.ASYNCHRONOUS:
                list = this.listAsynchronous;
                break;
        }

        AnimateAction animateAction = new AnimateAction(spriteView, coordinates);
        list.addLast(animateAction);

    }

    public bool isAnimating()
    {
        return !(this.listSynchronous.isEmpty() && this.listAsynchronous.isEmpty());
    }

    public bool isAnimatingSynchronous()
    {
        return !this.listSynchronous.isEmpty();
    }

    public bool isAnimatingAsynchronous()
    {
        return !this.listAsynchronous.isEmpty();
    }

    public void moveAsynchronousToSynchronous()
    {
        this.listSynchronous.addRange(this.listAsynchronous);
        this.listAsynchronous.clear();
    }

    public void moveAsynchronousToSynchronousLock(Action action)
    {
        moveAsynchronousToSynchronous();
        ManagerLock.INSTANCE.acquire(action);
    }

    private class AnimateAction
    {

        private SpriteView spriteView;
        private Vector2 coordinatesTarget;

        public AnimateAction(SpriteView spriteView, Vector2 coordinatesTarget)
        {
            this.spriteView = spriteView;
            this.coordinatesTarget = coordinatesTarget;
        }

        public void animate()
        {

            float speed = ManagerAnimation.INSTANCE.speed;
            float pixelsToMove = speed * Time.deltaTime;

            Vector2 positionCurrent = this.spriteView.getCoordinatesTopLeft();
            Vector2 positionNext = Vector2.MoveTowards(positionCurrent, this.coordinatesTarget, pixelsToMove);
            this.spriteView.relocateTopLeft(positionNext);

        }


        public bool isAnimating()
        {
            return this.spriteView.getCoordinatesTopLeft() != this.coordinatesTarget;
        }

    }

}
