using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteList : MonoBehaviour, IEnumerable
{

    public EList eList;
    public Vector2 listCoordinates, gapBetweenObjects = new Vector2(5, 5);
    public int objectsPerRow = -1;
    public Enums.LayerZList layerZOrder = Enums.LayerZList.TO_BACK_FIRST_SPRITEVIEW;
    public Enums.RearrangeType rearrangeType = Enums.RearrangeType.LINEAR;
    public Enums.DirectionHorizontal horizontalDirection = Enums.DirectionHorizontal.RIGHT;
    public Enums.DirectionVertical verticalDirection = Enums.DirectionVertical.DOWN;
    public Enums.PivotPosition pivotPosition = Enums.PivotPosition.TOP_LEFT;

    public ArrayList<GameObject> arrayList;
    private Vector2 objectPositionInList, coordinatesFirstObject, coordinatesObjectFinal, spriteDimensions;

    private void Start()
    {
        this.arrayList = new ArrayList<GameObject>();
    }

    public void animateAsynchronous()
    {
        executeAction(Enums.SpriteViewAction.ANIMATE, Enums.AnimateSynch.ASYNCHRONOUS);
    }

    public void animateSynchronous()
    {
        executeAction(Enums.SpriteViewAction.ANIMATE, Enums.AnimateSynch.SYNCHRONOUS);
    }

    public void animateSynchronousLock(Action action)
    {
        executeAction(Enums.SpriteViewAction.ANIMATE, Enums.AnimateSynch.SYNCHRONOUS);
        ManagerLock.INSTANCE.acquire(action);
    }

    public void relocateSprites()
    {
        executeAction(Enums.SpriteViewAction.RELOCATE, Enums.AnimateSynch.ASYNCHRONOUS);
    }

    private void executeAction(Enums.SpriteViewAction spriteViewActionEnum, Enums.AnimateSynch animateSynchEnum)
    {

        if (this.objectsPerRow == 0)
            return;

        foreach (GameObject gameObject in this.arrayList)
        {

            SpriteView spriteView = ManagerSpriteView.INSTANCE.list[gameObject];
            this.spriteDimensions = spriteView.getDimensions();
            calculateCoordinatesObjectFinal(this.arrayList.indexOf(gameObject));

            if (this.pivotPosition.Equals(Enums.PivotPosition.CENTER))
            {
                this.coordinatesObjectFinal.x -= spriteView.getWidth() / 2;
                this.coordinatesObjectFinal.y += spriteView.getHeight() / 2;
            }

            switch (spriteViewActionEnum)
            {

                case Enums.SpriteViewAction.RELOCATE:
                    spriteView.relocateTopLeft(this.coordinatesObjectFinal);
                    break;

                case Enums.SpriteViewAction.ANIMATE:
                    ManagerAnimation.INSTANCE.animateTopLeft(spriteView, this.coordinatesObjectFinal, animateSynchEnum);
                    break;

            }

        }

        handleLayerZ();

    }

    public void handleLayerZ()
    {

        ArrayList<GameObject> listLayerZ = this.arrayList.clone();

        if (this.layerZOrder.Equals(Enums.LayerZList.TO_FRONT_FIRST_SPRITEVIEW))
            listLayerZ.reverse();

        foreach (GameObject gameObject in listLayerZ)
            ManagerLayerZ.INSTANCE.toFront(gameObject);

    }

    private void calculateCoordinatesObjectFinal(int objectIndex)
    {

        switch (this.rearrangeType)
        {

            case Enums.RearrangeType.STATIC:
                handleRearrangeTypeEnumStatic();
                break;

            case Enums.RearrangeType.LINEAR:
                handleRearrangeTypeEnumLinear(objectIndex);
                break;

            case Enums.RearrangeType.PIVOT:
                handleRearrangeTypeEnumPivot(objectIndex);
                break;

        }

    }

    private void handleRearrangeTypeEnumStatic()
    {
        this.coordinatesObjectFinal = this.listCoordinates;
    }

    private void handleRearrangeTypeEnumLinear(int objectIndex)
    {
        calculateObjectPositionInList(objectIndex);
        this.coordinatesFirstObject = this.listCoordinates;
        calculateCoordinatesObjectFinal();
    }

    private void handleRearrangeTypeEnumPivot(int objectIndex)
    {

        calculateObjectPositionInList(objectIndex);

        int rows = 1, columns = this.arrayList.size();

        if (this.objectsPerRow != -1)
        {

            while (columns > this.objectsPerRow)
            {
                rows++;
                columns -= this.objectsPerRow;
            }

        }

        if (rows > 1)
            columns = this.objectsPerRow;

        float width = columns * this.spriteDimensions.x + (columns - 1) * this.gapBetweenObjects.x;
        float height = rows * this.spriteDimensions.y + (rows - 1) * this.gapBetweenObjects.y;

        this.coordinatesFirstObject = new Vector2(this.listCoordinates.x, this.listCoordinates.y);

        switch (this.horizontalDirection)
        {

            case Enums.DirectionHorizontal.RIGHT:
                this.coordinatesFirstObject.x -= width / 2;
                break;

            case Enums.DirectionHorizontal.LEFT:
                this.coordinatesFirstObject.x += width / 2 - this.spriteDimensions.x;
                break;

        }

        switch (this.verticalDirection)
        {

            case Enums.DirectionVertical.DOWN:
                this.coordinatesFirstObject.y += height / 2;
                break;

            case Enums.DirectionVertical.UP:
                this.coordinatesFirstObject.y -= height / 2 - this.spriteDimensions.y;
                break;

        }

        calculateCoordinatesObjectFinal();

    }

    private void calculateObjectPositionInList(int objectIndex)
    {

        this.objectPositionInList = new Vector2(0, objectIndex);

        if (this.objectsPerRow == -1)
            return;

        while (this.objectPositionInList.y >= this.objectsPerRow)
        {
            this.objectPositionInList.x++;
            this.objectPositionInList.y -= this.objectsPerRow;
        }

    }

    private void calculateCoordinatesObjectFinal()
    {

        // horizontal

        this.coordinatesObjectFinal.x = this.coordinatesFirstObject.x;

        switch (this.horizontalDirection)
        {

            case Enums.DirectionHorizontal.RIGHT:
                this.coordinatesObjectFinal.x += this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x += this.objectPositionInList.y * this.gapBetweenObjects.x;
                break;

            case Enums.DirectionHorizontal.LEFT:
                this.coordinatesObjectFinal.x -= this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x -= this.objectPositionInList.y * this.gapBetweenObjects.x;
                break;

        }

        // vertical

        this.coordinatesObjectFinal.y = this.coordinatesFirstObject.y;

        switch (this.verticalDirection)
        {

            case Enums.DirectionVertical.DOWN:
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.gapBetweenObjects.y;
                break;

            case Enums.DirectionVertical.UP:
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.gapBetweenObjects.y;
                break;

        }

    }

    public IEnumerator GetEnumerator()
    {
        return this.arrayList.GetEnumerator();
    }

}
