using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    public Vector2 spritePercentage;
    public GameObject spriteSelectPrefab;
    private Dictionary<SpriteView, GameObject> list;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<SpriteView, GameObject>();
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

        GameObject selectSpriteGameObject = ManagerObjectPool.INSTANCE.getObject(this.spriteSelectPrefab);
        SpriteView spriteViewSelect = ManagerSpriteView.INSTANCE.list[selectSpriteGameObject];

        float widthGameObject = spriteViewGameObject.getWidth();
        float heightGameObject = spriteViewGameObject.getHeight();

        float dimensionSpriteView = Mathf.Min(widthGameObject, heightGameObject);
        dimensionSpriteView /= 2;
        spriteViewSelect.setWidth(dimensionSpriteView);

        Vector2 coordinatesGameObject = spriteViewGameObject.getCoordinatesTopLeft();
        float centerX = coordinatesGameObject.x + this.spritePercentage.x * spriteViewGameObject.getWidth() / 100;
        float centerY = coordinatesGameObject.y - this.spritePercentage.y * spriteViewGameObject.getHeight() / 100;

        spriteViewSelect.relocateCenter(centerX, centerY);

        this.list.Add(spriteViewGameObject, selectSpriteGameObject);

    }

    private void deselectSprite(SpriteView spriteViewGameObject)
    {

        GameObject selectSpriteGameObject = this.list[spriteViewGameObject];
        SpriteView selectSpriteView = ManagerSpriteView.INSTANCE.list[selectSpriteGameObject];
        selectSpriteView.setActive(false);

        this.list.Remove(spriteViewGameObject);

    }

}
