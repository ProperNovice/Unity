using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListCredentials
{

    public Vector2 coordinatesList;
    [SerializeField] private Vector2 gapBetweenObjects = new Vector2(5, 5);
    [SerializeField] private int objectsPerRow = -1;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeTypeEnum = Enums.RearrangeTypeEnum.LINEAR;
    [SerializeField] private Enums.DirectionHorizontalEnum directionHorizontalEnum = Enums.DirectionHorizontalEnum.RIGHT;
    [SerializeField] private Enums.DirectionVerticalEnum directionVerticalEnum = Enums.DirectionVerticalEnum.DOWN;
    [SerializeField] private Enums.RelocateTypeEnum relocateTypeEnum = Enums.RelocateTypeEnum.TOP_LEFT;

    private int objectIndex;
    private Vector2 objectPosition, firstObjectCoordinates;

    public Vector2 getCoordinates(int index)
    {

        this.objectIndex = index;

        switch (this.rearrangeTypeEnum)
        {

            case Enums.RearrangeTypeEnum.STATIC:
                return this.coordinatesList;

            case Enums.RearrangeTypeEnum.LINEAR:
                break;

            case Enums.RearrangeTypeEnum.PIVOT:
                break;

        }

        calculateObjectRowColumn();

        return new Vector2();
    }

    private void calculateObjectRowColumn()
    {

        this.objectPosition = new Vector2(0, this.objectIndex);

        if (this.objectsPerRow == -1)
            return;

        while (this.objectPosition.y >= this.objectsPerRow)
        {
            this.objectPosition.y -= this.objectsPerRow;
            this.objectPosition.x++;
        }

    }

}
