using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManagerAnimation : MonoBehaviour
{

    public static ManagerAnimation INSTANCE;
    [SerializeField] private float speed = 1200;
    private ArrayList<AnimateAction> listSynchronous, listAsynchronous;

    private void Awake()
    {

        INSTANCE = this;

        this.listSynchronous = new ArrayList<AnimateAction>();
        this.listAsynchronous = new ArrayList<AnimateAction>();

    }

    public void animateTopLeft(SpriteView spriteView, Vector2 coordinates, Enums.AnimateSynch animateSynch)
    {

        removeSpriteViewIfAnimating(spriteView);

        ArrayList<AnimateAction> list = new ArrayList<AnimateAction>();

        switch (animateSynch)
        {
            case Enums.AnimateSynch.SYNCHRONOUS:
                list = this.listSynchronous;
                break;

            case Enums.AnimateSynch.ASYNCHRONOUS:
                list = this.listAsynchronous;
                break;
        }

        AnimateAction animateAction = new AnimateAction(spriteView, coordinates, list);

    }

    public void animateCenter(SpriteView spriteView, Vector2 coordinates, Enums.AnimateSynch animateSynch)
    {
        Vector2 coordinatesFinal = new Vector2(coordinates.x - spriteView.getWidth() / 2, coordinates.y + spriteView.getHeight() / 2);
        animateTopLeft(spriteView, coordinatesFinal, animateSynch);
    }

    private void removeSpriteViewIfAnimating(SpriteView spriteView)
    {
        checkListForDuplicateSpriteView(this.listAsynchronous, spriteView);
        checkListForDuplicateSpriteView(this.listSynchronous, spriteView);
    }

    private void checkListForDuplicateSpriteView(ArrayList<AnimateAction> list, SpriteView spriteView)
    {
        foreach (AnimateAction animateAction in list.clone())
        {
            if (animateAction.spriteView.Equals(spriteView))
                list.remove(animateAction);
        }
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
        this.listSynchronous.addLast(this.listAsynchronous.removeAll());
    }

    private class AnimateAction
    {

        public SpriteView spriteView;
        private Vector2 coordinatesTarget;
        private ArrayList<AnimateAction> list;

        public AnimateAction(SpriteView spriteView, Vector2 coordinatesTarget, ArrayList<AnimateAction> list)
        {
            this.spriteView = spriteView;
            this.coordinatesTarget = coordinatesTarget;
            this.list = list;

            if (!isAnimating())
                return;

            this.list.addLast(this);
            Model.INSTANCE.StartCoroutine(animate());
        }

        private IEnumerator animate()
        {

            while (isAnimating())
            {

                float speed = ManagerAnimation.INSTANCE.speed;
                float pixelsToMove = speed * Time.deltaTime;

                Vector2 positionCurrent = this.spriteView.getCoordinatesTopLeft();
                Vector2 positionNext = Vector2.MoveTowards(positionCurrent, this.coordinatesTarget, pixelsToMove);
                this.spriteView.relocateTopLeft(positionNext);

                yield return null;

            }

            this.list.remove(this);

        }

        private bool isAnimating()
        {
            return this.spriteView.getCoordinatesTopLeft() != this.coordinatesTarget;
        }

    }

}
