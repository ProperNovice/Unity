using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    public float percentageX = 50, percentageY = 50;
    public GameObject spriteSelect;
    private Dictionary<SpriteView, SpriteView> list;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<SpriteView, SpriteView>();
    }

    public void reverseSelect(GameObject gameObject)
    {

        SpriteView spriteView = ManagerSpriteView.INSTANCE.list[gameObject];

        if (this.list.ContainsKey(spriteView))
            deselectSprite(spriteView);
        else
            selectSprite(spriteView);

    }

    private void selectSprite(SpriteView spriteViewGameObject)
    {

        GameObject spriteSelect = Instantiate(this.spriteSelect);
        SpriteView spriteViewSelect = ManagerSpriteView.INSTANCE.list[spriteSelect];

        float widthGameObject = spriteViewGameObject.getWidth();
        float heightGameObject = spriteViewGameObject.getHeight();

        float dimensionSpriteView = Mathf.Min(widthGameObject, heightGameObject);
        dimensionSpriteView /= 2;
        spriteViewSelect.setWidth(dimensionSpriteView);

        Vector2 coordinatesGameObject = spriteViewGameObject.getCoordinatesTopLeft();
        float centerX = coordinatesGameObject.x + this.percentageX * spriteViewGameObject.getWidth() / 100;
        float centerY = coordinatesGameObject.y - this.percentageY * spriteViewGameObject.getHeight() / 100;

        spriteViewSelect.relocateCenter(centerX, centerY);

        this.list.Add(spriteViewGameObject, spriteViewSelect);

    }

    private void deselectSprite(SpriteView spriteViewGameObject)
    {

    }

}
