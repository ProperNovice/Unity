using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{

    public enum DirectionHorizontal
    {
        RIGHT, LEFT
    }

    public enum DirectionVertical
    {
        DOWN, UP
    }

    public enum RearrangeType
    {
        LINEAR, STATIC, PIVOT
    }

    public enum PivotPosition
    {
        TOP_LEFT, CENTER
    }

    public enum AnimateSynch
    {
        ASYNCHRONOUS, SYNCHRONOUS
    }

    public enum SpriteViewAction
    {
        RELOCATE, ANIMATE
    }

    public enum LayerZList
    {
        TO_BACK_FIRST_SPRITEVIEW, TO_FRONT_FIRST_SPRITEVIEW
    }

}
