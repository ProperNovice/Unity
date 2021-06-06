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

    public void animateTopLeft(SpriteView spriteView, Vector2 coordinates,
        Enums.AnimateSynch animateSynch, SpriteList spriteList)
    {

        removeSpriteViewIfAnimating(spriteView);

        AnimateToken animateToken = new AnimateToken(spriteView, coordinates, spriteList);

        if (!animateToken.isAnimating())
            return;

        ArrayList<AnimateToken> list = null;

        switch (animateSynch)
        {
            case Enums.AnimateSynch.SYNCHRONOUS:
                list = this.listSynchronous;
                break;

            case Enums.AnimateSynch.ASYNCHRONOUS:
                list = this.listAsynchronous;
                break;
        }

        list.addLast(animateToken);
        StartCoroutine(animateToken.animate());

    }

    public void animateTopLeft(SpriteView spriteView, Vector2 coordinates,
        Enums.AnimateSynch animateSynch)
    {
        animateTopLeft(spriteView, coordinates, animateSynch, null);
    }

    public void animateCenter(SpriteView spriteView, Vector2 coordinates, Enums.AnimateSynch animateSynch)
    {
        Vector2 coordinatesFinal = new Vector2(coordinates.x - spriteView.getWidth() / 2, coordinates.y + spriteView.getHeight() / 2);
        animateTopLeft(spriteView, coordinatesFinal, animateSynch, null);
    }

    private void removeSpriteViewIfAnimating(SpriteView spriteView)
    {
        ArrayList<ArrayList<AnimateToken>> list = new ArrayList<ArrayList<AnimateToken>>();
        list.addLast(this.listSynchronous);
        list.addLast(this.listAsynchronous);

        foreach (ArrayList<AnimateToken> listToken in list)
        {

            foreach (AnimateToken animateAction in listToken.clone())
            {
                if (!animateAction.spriteView.Equals(spriteView))
                    continue;

                listToken.remove(animateAction);
                animateAction.stopAnimation();
            }
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

    public void stopAnimations()
    {
        ArrayList<AnimateToken> list = new ArrayList<AnimateToken>();

        list.addLast(this.listSynchronous.removeAll());
        list.addLast(this.listAsynchronous.removeAll());

        while (!list.isEmpty())
            list.removeRandom().stopAnimation();

    }

    private class AnimateToken
    {

        public SpriteView spriteView;
        private Vector2 coordinatesTarget;
        private bool stopCoroutine = false;
        private SpriteList spriteList = null;

        public AnimateToken(SpriteView spriteView, Vector2 coordinatesTarget)
        {
            this.spriteView = spriteView;
            this.coordinatesTarget = coordinatesTarget;
        }

        public AnimateToken(SpriteView spriteView, Vector2 coordinatesTarget, SpriteList spriteList)
            : this(spriteView, coordinatesTarget)
        {
            this.spriteList = spriteList;
        }

        public IEnumerator animate()
        {

            float speed = ManagerAnimation.INSTANCE.speed;

            while (isAnimating())
            {

                if (this.stopCoroutine)
                    yield break;

                this.spriteView.toFront();
                executeLayerZ();

                float pixelsToMove = speed * Time.deltaTime;

                Vector2 positionCurrent = this.spriteView.getCoordinatesTopLeft();
                Vector2 positionNext = Vector2.MoveTowards(positionCurrent, this.coordinatesTarget, pixelsToMove);
                this.spriteView.relocateTopLeft(positionNext);

                yield return null;

            }

            executeLayerZ();

            ManagerAnimation.INSTANCE.removeSpriteViewIfAnimating(this.spriteView);

        }

        private void executeLayerZ()
        {

            if (this.spriteList.rearrangeType.Equals(Enums.RearrangeType.LINEAR))
                if (spriteList.percentageGapBetweenSprites.x == 100)
                    if (spriteList.percentageGapBetweenSprites.y == 100)
                        return;

            this.spriteList.executeLayerZ();

        }

        public bool isAnimating()
        {
            return this.spriteView.getCoordinatesTopLeft() != this.coordinatesTarget;
        }

        public void stopAnimation()
        {
            this.stopCoroutine = true;
        }

    }

}