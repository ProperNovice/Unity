using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteList : MonoBehaviour
{

    [SerializeField] private EList list;
    public Vector2 listCoordinates, gapBetweenObjects = new Vector2(5, 5);
    [SerializeField] private int objectsPerRow = -1, capacity = -1;
    [SerializeField] private Enums.LayerZListEnum layerZOrder = Enums.LayerZListEnum.TO_BACK_FIRST_SPRITEVIEW;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeTypeEnum = Enums.RearrangeTypeEnum.LINEAR;
    [SerializeField] private Enums.DirectionHorizontalEnum horizontalDirectionEnum = Enums.DirectionHorizontalEnum.RIGHT;
    [SerializeField] private Enums.DirectionVerticalEnum verticalDirectionEnum = Enums.DirectionVerticalEnum.DOWN;
    [SerializeField] private Enums.RelocatePositionEnum relocatePositionEnum = Enums.RelocatePositionEnum.TOP_LEFT;

    public ArrayList<GameObject> arrayList;
    private Vector2 objectPositionInList, coordinatesFirstObject, coordinatesObjectFinal, spriteDimensions;

    private void Start()
    {
        this.arrayList = new ArrayList<GameObject>(this.capacity);
        ManagerList.INSTANCE.lists.Add(this.list, this);
    }

    private void Update()
    {
        // relocateSprites();
    }

    public void animateAsynchronous()
    {
        executeAction(Enums.SpriteViewActionEnum.ANIMATE, Enums.AnimateSynchEnum.ASYNCHRONOUS);
    }

    public void animateSynchronous()
    {
        executeAction(Enums.SpriteViewActionEnum.ANIMATE, Enums.AnimateSynchEnum.SYNCHRONOUS);
    }

    public void animateSynchronousLock(Action action)
    {
        executeAction(Enums.SpriteViewActionEnum.ANIMATE, Enums.AnimateSynchEnum.SYNCHRONOUS);
        ManagerLock.INSTANCE.acquire(action);
    }

    public void relocateSprites()
    {
        executeAction(Enums.SpriteViewActionEnum.RELOCATE, Enums.AnimateSynchEnum.ASYNCHRONOUS);
    }

    private void executeAction(Enums.SpriteViewActionEnum spriteViewActionEnum, Enums.AnimateSynchEnum animateSynchEnum)
    {

        if (this.objectsPerRow == 0)
            return;

        foreach (GameObject gameObject in this.arrayList)
        {

            SpriteView spriteView = ManagerSpriteView.INSTANCE.list[gameObject];
            this.spriteDimensions = spriteView.getDimensions();
            calculateCoordinatesObjectFinal(this.arrayList.indexOf(gameObject));

            if (this.relocatePositionEnum.Equals(Enums.RelocatePositionEnum.CENTER))
            {
                this.coordinatesObjectFinal.x -= spriteView.getWidth() / 2;
                this.coordinatesObjectFinal.y += spriteView.getHeight() / 2;
            }

            switch (spriteViewActionEnum)
            {

                case Enums.SpriteViewActionEnum.RELOCATE:
                    spriteView.relocateTopLeft(this.coordinatesObjectFinal);
                    break;

                case Enums.SpriteViewActionEnum.ANIMATE:
                    ManagerAnimation.INSTANCE.animate(spriteView, this.coordinatesObjectFinal, animateSynchEnum);
                    break;

            }

        }

        handleLayerZ();

    }

    public void handleLayerZ()
    {

        ArrayList<GameObject> listLayerZ = this.arrayList.clone();

        if (this.layerZOrder.Equals(Enums.LayerZListEnum.TO_FRONT_FIRST_SPRITEVIEW))
            listLayerZ.reverse();

        foreach (GameObject gameObject in listLayerZ)
            ManagerLayerZ.INSTANCE.toFront(gameObject);

    }

    private void calculateCoordinatesObjectFinal(int objectIndex)
    {

        switch (this.rearrangeTypeEnum)
        {

            case Enums.RearrangeTypeEnum.STATIC:
                handleRearrangeTypeEnumStatic();
                break;

            case Enums.RearrangeTypeEnum.LINEAR:
                handleRearrangeTypeEnumLinear(objectIndex);
                break;

            case Enums.RearrangeTypeEnum.PIVOT:
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

        switch (this.horizontalDirectionEnum)
        {

            case Enums.DirectionHorizontalEnum.RIGHT:
                this.coordinatesFirstObject.x -= width / 2;
                break;

            case Enums.DirectionHorizontalEnum.LEFT:
                this.coordinatesFirstObject.x += width / 2 - this.spriteDimensions.x;
                break;

        }

        switch (this.verticalDirectionEnum)
        {

            case Enums.DirectionVerticalEnum.DOWN:
                this.coordinatesFirstObject.y += height / 2;
                break;

            case Enums.DirectionVerticalEnum.UP:
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

        switch (this.horizontalDirectionEnum)
        {

            case Enums.DirectionHorizontalEnum.RIGHT:
                this.coordinatesObjectFinal.x += this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x += this.objectPositionInList.y * this.gapBetweenObjects.x;
                break;

            case Enums.DirectionHorizontalEnum.LEFT:
                this.coordinatesObjectFinal.x -= this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x -= this.objectPositionInList.y * this.gapBetweenObjects.x;
                break;

        }

        // vertical

        this.coordinatesObjectFinal.y = this.coordinatesFirstObject.y;

        switch (this.verticalDirectionEnum)
        {

            case Enums.DirectionVerticalEnum.DOWN:
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.gapBetweenObjects.y;
                break;

            case Enums.DirectionVerticalEnum.UP:
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.gapBetweenObjects.y;
                break;

        }

    }

}
