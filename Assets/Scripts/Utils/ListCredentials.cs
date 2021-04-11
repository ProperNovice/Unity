using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListCredentials
{

    public Vector2 coordinatesList;
    [SerializeField] private Vector2 gapBetweenObjects = new Vector2(5, 5);
    [SerializeField] private int objectsPerRow = -1;
    [SerializeField] private float firstObjectX, firstObjectY;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeTypeEnum = Enums.RearrangeTypeEnum.LINEAR;
    [SerializeField] private Enums.DirectionHorizontalEnum directionHorizontalEnum = Enums.DirectionHorizontalEnum.RIGHT;
    [SerializeField] private Enums.DirectionVerticalEnum directionVerticalEnum = Enums.DirectionVerticalEnum.DOWN;
    [SerializeField] private Enums.RelocateTypeEnum relocateTypeEnum = Enums.RelocateTypeEnum.TOP_LEFT;

}
