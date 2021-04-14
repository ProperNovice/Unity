using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteList : MonoBehaviour
{

    [SerializeField] private EList list;
    [SerializeField] private Vector2 listCoordinates, gapBetweenObjects = new Vector2(5, 5);
    [SerializeField] private int objectsPerRow = -1, listCapacity = -1;
    [SerializeField] private Enums.RearrangeTypeEnum rearrangeType = Enums.RearrangeTypeEnum.LINEAR;
    [SerializeField] private Enums.DirectionHorizontalEnum horizontalDirection = Enums.DirectionHorizontalEnum.RIGHT;
    [SerializeField] private Enums.DirectionVerticalEnum verticalDirection = Enums.DirectionVerticalEnum.DOWN;
    [SerializeField] private Enums.RelocatePositionEnum relocatePosition = Enums.RelocatePositionEnum.TOP_LEFT;

    public ArrayList<GameObject> arrayList;
    private Vector2 objectPositionInList, coordinatesFirstObject, coordinatesObjectFinal, spriteDimensions;

    private void Start()
    {
        this.arrayList = new ArrayList<GameObject>(this.listCapacity);
        ManagerList.INSTANCE.lists.put(this.list, this);
    }

    private void Update()
    {

    }

    public void animateAsynchronous()
    {
        executeAction(Enums.SpriteViewActionEnum.ANIMATE, Enums.AnimateSynchEnum.ASYNCHRONOUS);
    }

    public void animateSynchronous()
    {
        executeAction(Enums.SpriteViewActionEnum.ANIMATE, Enums.AnimateSynchEnum.SYNCHRONOUS);
    }

    public void animateSynchronousLock()
    {

    }

    public void relocateSprites()
    {
        executeAction(Enums.SpriteViewActionEnum.RELOCATE, Enums.AnimateSynchEnum.ASYNCHRONOUS);
    }

    public void relocateList(Vector2 vector2)
    {
        this.listCoordinates = vector2;
    }

    private void executeAction(Enums.SpriteViewActionEnum spriteViewActionEnum, Enums.AnimateSynchEnum animateSynchEnum)
    {

        if (this.objectsPerRow == 0)
            return;

        foreach (GameObject gameObject in this.arrayList)
        {

            SpriteView spriteView = gameObject.GetComponent<SpriteView>();
            this.spriteDimensions = spriteView.getDimensions();
            Vector2 vector2 = getCoordinates(this.arrayList.indexOf(gameObject));

            switch (spriteViewActionEnum)
            {

                case Enums.SpriteViewActionEnum.RELOCATE:

                    switch (this.relocatePosition)
                    {
                        case Enums.RelocatePositionEnum.CENTER:
                            spriteView.relocateCenter(vector2);
                            break;

                        case Enums.RelocatePositionEnum.TOP_LEFT:
                            spriteView.relocateTopLeft(vector2);
                            break;
                    }

                    break;

                case Enums.SpriteViewActionEnum.ANIMATE:
                    ManagerAnimation.INSTANCE.animate(spriteView, vector2, animateSynchEnum, this.relocatePosition);
                    break;

            }

        }

    }

    private Vector2 getCoordinates(int objectIndex)
    {

        switch (this.rearrangeType)
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

        return this.coordinatesObjectFinal;
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

        this.coordinatesFirstObject = new Vector2(this.listCoordinates.x - width / 2, this.listCoordinates.y + height / 2);

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
                this.coordinatesObjectFinal.y -= this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y -= (this.objectPositionInList.x - 1) * this.gapBetweenObjects.y;
                break;

            case Enums.DirectionVerticalEnum.UP:
                this.coordinatesObjectFinal.y += this.objectPositionInList.x * this.spriteDimensions.y;
                this.coordinatesObjectFinal.y += (this.objectPositionInList.x - 1) * this.gapBetweenObjects.y;
                break;

        }

    }


}
