using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManagerAnimation : MonoBehaviour
{

    public static ManagerAnimation INSTANCE;
    [SerializeField] private float speed = 1200;
    private ArrayList<AnimateToken> listSynchronous, listAsynchronous;

    private void Awake()
    {

        INSTANCE = this;

        this.listSynchronous = new ArrayList<AnimateToken>();
        this.listAsynchronous = new ArrayList<AnimateToken>();

    }

    public void animateTopLeft(SpriteView spriteView, Vector2 coordinates, Enums.AnimateSynch animateSynch)
    {

        removeSpriteViewIfAnimating(spriteView);

        ArrayList<AnimateToken> list = new ArrayList<AnimateToken>();

        switch (animateSynch)
        {
            case Enums.AnimateSynch.SYNCHRONOUS:
                list = this.listSynchronous;
                break;

            case Enums.AnimateSynch.ASYNCHRONOUS:
                list = this.listAsynchronous;
                break;
        }

        AnimateToken animateToken = new AnimateToken(spriteView, coordinates);

        if (!animateToken.isAnimating())
            return;

        list.addLast(animateToken);
        StartCoroutine(animateToken.animate());

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

    private void checkListForDuplicateSpriteView(ArrayList<AnimateToken> list, SpriteView spriteView)
    {
        foreach (AnimateToken animateAction in list.clone())
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

    private class AnimateToken
    {

        public SpriteView spriteView;
        private Vector2 coordinatesTarget;

        public AnimateToken(SpriteView spriteView, Vector2 coordinatesTarget)
        {
            this.spriteView = spriteView;
            this.coordinatesTarget = coordinatesTarget;
        }

        public IEnumerator animate()
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

            ManagerAnimation.INSTANCE.removeSpriteViewIfAnimating(this.spriteView);

        }

        public bool isAnimating()
        {
            return this.spriteView.getCoordinatesTopLeft() != this.coordinatesTarget;
        }

    }

}