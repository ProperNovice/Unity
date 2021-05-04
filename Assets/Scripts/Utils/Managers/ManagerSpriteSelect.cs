using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    public GameObject spriteSelectPrefab;
    public Vector2 spritePercentage;
    private Dictionary<GameObject, GameObject> list;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<GameObject, GameObject>();
    }

    public void reverseSelect(GameObject gameObject)
    {

        SpriteView spriteView = ManagerSpriteView.INSTANCE.list[gameObject];

        if (this.list.ContainsKey(gameObject))
            deselectSprite(spriteView, gameObject);
        else
            selectSprite(spriteView, gameObject);

    }

    private void selectSprite(SpriteView spriteViewGameObject, GameObject gameObject)
    {

        GameObject selectSpriteGameObject = ManagerObjectPool.INSTANCE.getGameObject(this.spriteSelectPrefab);
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

        this.list.Add(gameObject, selectSpriteGameObject);

    }

    private void deselectSprite(SpriteView spriteViewGameObject, GameObject gameObject)
    {

        GameObject selectSpriteGameObject = this.list[gameObject];
        SpriteView selectSpriteView = ManagerSpriteView.INSTANCE.list[selectSpriteGameObject];
        selectSpriteView.setActive(false);

        this.list.Remove(gameObject);

    }

    public int sizeSelected()
    {
        return this.list.Count;
    }

    public ArrayList<GameObject> getSelectedGameObjectsDeselectClear()
    {

        ArrayList<GameObject> gameObjects = new ArrayList<GameObject>();

        foreach (GameObject gameObject in this.list.Keys)
            gameObjects.addLast(gameObject);

        foreach (GameObject gameObject in gameObjects)
            reverseSelect(gameObject);

        return gameObjects;

    }

    public GameObject getGameObjectKey(GameObject gameObjectValue)
    {
        foreach (GameObject gameObject in this.list.Keys)
            if (this.list[gameObject].Equals(gameObjectValue))
                return gameObject;

        ShutDown.execute("gameObject not found");
        return null;
    }

}
