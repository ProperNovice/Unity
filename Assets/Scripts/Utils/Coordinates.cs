using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coordinates
{

    [SerializeField] private Vector2 coordinatesList, gapBetweenObjects;
    [SerializeField] private int objectsPerRow;
    [SerializeField] private float firstObjectX, firstObjectY;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeTypeEnum;
    [SerializeField] private Enums.DirectionHorizontalEnum directionHorizontalEnum;
    [SerializeField] private Enums.DirectionVerticalEnum directionVerticalEnum;
    [SerializeField] private Enums.RelocateTypeEnum relocateTypeEnum;

}
