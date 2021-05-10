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

        if (this.list.ContainsKey(gameObject))
            deselectSprite(gameObject);
        else
            selectSprite(gameObject);

    }

    private void selectSprite(GameObject gameObject)
    {

        GameObject selectSpriteGameObject = ManagerObjectPool.INSTANCE.getGameObject(this.spriteSelectPrefab);
        SpriteView spriteViewSelect = selectSpriteGameObject.GetComponent<SpriteView>();
        SpriteView spriteViewGameObject = gameObject.GetComponent<SpriteView>();

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

    private void deselectSprite(GameObject gameObject)
    {

        GameObject selectSpriteGameObject = this.list[gameObject];
        selectSpriteGameObject.SetActive(false);

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
