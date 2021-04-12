using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListCredentials
{

    public Vector2 coordinatesList;
    [SerializeField] private Vector2 gapBetweenObjects = new Vector2(5, 5);
    [SerializeField] private int objectsPerRow = -1;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeType = Enums.RearrangeTypeEnum.LINEAR;
    [SerializeField] private Enums.DirectionHorizontalEnum horizontaDirection = Enums.DirectionHorizontalEnum.RIGHT;
    [SerializeField] private Enums.DirectionVerticalEnum verticalDirection = Enums.DirectionVerticalEnum.DOWN;

    private int objectIndex, listSize;
    private Vector2 objectPositionInList, coordinatesFirstObject, coordinatesObjectFinal, spriteDimensions;

    public Vector2 getCoordinates(int index, Vector2 spriteDimensions, int listSize)
    {
        this.spriteDimensions = spriteDimensions;
        this.listSize = listSize;
        return getCoordinates(index);
    }

    public Vector2 getCoordinates(int index)
    {

        Debug.Log(this.objectsPerRow);
        Debug.Log(this.rearrangeType);

        this.objectIndex = index;

        switch (this.rearrangeType)
        {

            case Enums.RearrangeTypeEnum.STATIC:
                handleRearrangeTypeEnumStatic();
                break;

            case Enums.RearrangeTypeEnum.LINEAR:
                handleRearrangeTypeEnumLinear();
                break;

            case Enums.RearrangeTypeEnum.PIVOT:
                handleRearrangeTypeEnumPivot();
                break;

        }

        return this.coordinatesObjectFinal;
    }

    private void handleRearrangeTypeEnumStatic()
    {
        this.coordinatesObjectFinal = this.coordinatesList;
    }

    private void handleRearrangeTypeEnumLinear()
    {
        calculateObjectPositionInList();
        this.coordinatesFirstObject = this.coordinatesList;
        calculateCoordinatesObjectFinal();
    }

    private void handleRearrangeTypeEnumPivot()
    {

        calculateObjectPositionInList();

        int rows = 1, columns = this.listSize;

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

        this.coordinatesFirstObject = new Vector2(this.coordinatesList.x - width / 2, this.coordinatesList.y - height / 2);

        calculateCoordinatesObjectFinal();

    }

    private void calculateObjectPositionInList()
    {

        this.objectPositionInList = new Vector2(0, this.objectIndex);

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

        switch (this.horizontaDirection)
        {

            case Enums.DirectionHorizontalEnum.RIGHT:
                this.coordinatesObjectFinal.x += this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x += (this.objectPositionInList.y - 1) * this.gapBetweenObjects.x;
                break;

            case Enums.DirectionHorizontalEnum.LEFT:
                this.coordinatesObjectFinal.x -= this.objectPositionInList.y * this.spriteDimensions.x;
                this.coordinatesObjectFinal.x -= (this.objectPositionInList.y - 1) * this.gapBetweenObjects.x;
                break;

        }

        // vertical

        this.coordinatesObjectFinal.y = this.coordinatesFirstObject.y;

        switch (this.verticalDirection)
        {

            case Enums.DirectionVerticalEnum.DOWN:
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y += (this.objectPositionInList.x - 1) * this.gapBetweenObjects.y;
                break;

            case Enums.DirectionVerticalEnum.UP:
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y -= (this.objectPositionInList.x - 1) * this.gapBetweenObjects.y;
                break;

        }

    }

}
