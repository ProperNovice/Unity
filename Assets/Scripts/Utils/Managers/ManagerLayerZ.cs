using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLayerZ : MonoBehaviour
{

    public static ManagerLayerZ INSTANCE;
    private Dictionary<ELayerZ, ArrayList<GameObject>> listLayerZ;
    private Dictionary<GameObject, SpriteView> listSpriteViews;

    private void Awake()
    {

        INSTANCE = this;

        this.listLayerZ = new Dictionary<ELayerZ, ArrayList<GameObject>>();

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
            this.listLayerZ.Add(eLayerZ, new ArrayList<GameObject>());

        this.listSpriteViews = new Dictionary<GameObject, SpriteView>();

    }

    public void toFront(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addLast(gameObject);

        executeToFront();

    }

    public void toBack(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addFirst(gameObject);

        executeToFront();

    }

    public void executeToFront()
    {

        int sortingOrder = -1;

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
        {

            foreach (GameObject gameObject in this.listLayerZ[eLayerZ])
            {
                SpriteView spriteView = this.listSpriteViews[gameObject];
                spriteView.setSortingOrder(sortingOrder++);
            }

        }

    }

    private ArrayList<GameObject> getListContainingGameObject(GameObject gameObject)
    {

        foreach (ELayerZ eLayerZ in this.listLayerZ.Keys)
            if (this.listLayerZ[eLayerZ].contains(gameObject))
                return this.listLayerZ[eLayerZ];

        ShutDown.execute(this);

        return new ArrayList<GameObject>();

    }

    public void addGameObject(SpriteView spriteView)
    {
        this.listLayerZ[spriteView.layerZ].addLast(spriteView.gameObject);
        this.listSpriteViews.Add(spriteView.gameObject, spriteView);
    }

}
