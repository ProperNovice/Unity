using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManagerAnimation : MonoBehaviour
{

    public static ManagerAnimation INSTANCE;
    [SerializeField] private int speed = 1200;
    private ArrayList<AnimateAction> listSynchronous, listAsynchronous;

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

        switch (animateSynchEnum)
        {
            case Enums.AnimateSynchEnum.SYNCHRONOUS:
                this.listSynchronous.addLast(new AnimateAction(spriteView, coordinates, this.speed));
                break;

            case Enums.AnimateSynchEnum.ASYNCHRONOUS:
                this.listAsynchronous.addLast(new AnimateAction(spriteView, coordinates, this.speed));
                break;
        }

    }

    private class AnimateAction
    {

        private SpriteView spriteView;
        private Vector2 coordinatesTarget;
        private int speed;

        public AnimateAction(SpriteView spriteView, Vector2 coordinatesTarget, int speed)
        {
            this.spriteView = spriteView;
            this.coordinatesTarget = coordinatesTarget;
            this.speed = speed;
        }

        public void animate()
        {

            float pixelsToMove = speed * Time.deltaTime;

            Logger.log(this.speed + " " + pixelsToMove);

            Vector2 positionCurrent = this.spriteView.getCoordinates();
            Vector2 positionNext = Vector2.MoveTowards(positionCurrent, this.coordinatesTarget, pixelsToMove);

            this.spriteView.relocateCenter(positionNext);

        }

        public bool isAnimating()
        {
            return this.spriteView.getCoordinates() != this.coordinatesTarget;
        }

    }

}
