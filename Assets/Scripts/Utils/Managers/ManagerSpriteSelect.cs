using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    public GameObject spriteSelectPrefab;
    public Vector2 spritePercentage;
    public float positionDimension;
    private Dictionary<GameObject, GameObject> listSprites;
    private Dictionary<GameObject, GameObject> listPositions;

    private void Awake()
    {
        INSTANCE = this;
        this.listSprites = new Dictionary<GameObject, GameObject>();
        this.listPositions = new Dictionary<GameObject, GameObject>();
    }

    public void reverseSelectSprites(GameObject gameObject)
    {

        if (this.listSprites.ContainsKey(gameObject))
            deselectSprite(gameObject);
        else
            selectSprite(gameObject);

    }

    private void selectSprite(GameObject gameObject)
    {

        GameObject selectSpriteGameObject = ManagerObjectPool.INSTANCE.getGameObjectActivate(this.spriteSelectPrefab);
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

        this.listSprites.Add(gameObject, selectSpriteGameObject);

    }

    private void deselectSprite(GameObject gameObject)
    {

        GameObject selectSpriteGameObject = this.listSprites[gameObject];
        selectSpriteGameObject.SetActive(false);

        this.listSprites.Remove(gameObject);

    }

    public void reverseSelectPosition(GameObject gameObject)
    {

        if (this.listPositions.ContainsKey(gameObject))
            deselectPosition(gameObject);
        else
            selectPosition(gameObject);

    }

    private void selectPosition(GameObject gameObject)
    {
        GameObject selectSpriteGameObject = ManagerObjectPool.INSTANCE.getGameObjectActivate(this.spriteSelectPrefab);

        SpriteView selectSpriteView = selectSpriteGameObject.GetComponent<SpriteView>();
        selectSpriteView.setWidth(this.positionDimension);
        selectSpriteView.relocateCenter(gameObject.transform.position);

        Logger.log(selectSpriteGameObject.transform.position);

        this.listPositions.Add(gameObject, selectSpriteGameObject);
    }

    private void deselectPosition(GameObject gameObject)
    {
        GameObject selectSpriteGameObject = this.listPositions[gameObject];
        selectSpriteGameObject.SetActive(false);

        this.listPositions.Remove(gameObject);
    }

    public int sizeSelected()
    {
        return this.listSprites.Count + this.listPositions.Count;
    }

    public ArrayList<GameObject> getSelectedGameObjectsDeselectClear()
    {

        ArrayList<GameObject> gameObjectsSprites = new ArrayList<GameObject>();
        ArrayList<GameObject> gameObjectsPositions = new ArrayList<GameObject>();

        foreach (GameObject gameObject in this.listSprites.Keys)
            gameObjectsSprites.addLast(gameObject);

        foreach (GameObject gameObject in this.listPositions.Keys)
            gameObjectsPositions.addLast(gameObject);

        foreach (GameObject gameObject in gameObjectsSprites)
            reverseSelectSprites(gameObject);

        foreach (GameObject gameObject in gameObjectsPositions)
            reverseSelectPosition(gameObject);

        ArrayList<GameObject> list = new ArrayList<GameObject>();
        list.addLast(gameObjectsSprites);
        list.addLast(gameObjectsPositions);

        return list;

    }

    public GameObject getGameObjectKey(GameObject gameObjectValue)
    {
        foreach (GameObject gameObject in this.listSprites.Keys)
            if (this.listSprites[gameObject].Equals(gameObjectValue))
                return gameObject;

        foreach (GameObject gameObject in this.listPositions.Keys)
            if (this.listPositions[gameObject].Equals(gameObjectValue))
                return gameObject;

        ShutDown.execute("gameObject not found");
        return null;
    }

}
