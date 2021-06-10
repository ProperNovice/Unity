using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLayerZ : MonoBehaviour
{

    public static ManagerLayerZ INSTANCE;
    private Dictionary<ELayerZ, ArrayList<GameObject>> listLayerZ;
    private Dictionary<GameObject, SpriteView> listSpriteViews;
    private bool executeToFront;

    private void Awake()
    {

        INSTANCE = this;

        this.listLayerZ = new Dictionary<ELayerZ, ArrayList<GameObject>>();

        foreach (ELayerZ eLayerZ in System.Enum.GetValues(typeof(ELayerZ)))
            this.listLayerZ.Add(eLayerZ, new ArrayList<GameObject>());

        this.listSpriteViews = new Dictionary<GameObject, SpriteView>();
        this.executeToFront = false;

    }

    public void toFront(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addLast(gameObject);

        if (this.executeToFront)
            return;

        this.executeToFront = true;
        StartCoroutine(update());
    }

    public void toBack(GameObject gameObject)
    {

        ArrayList<GameObject> arrayListGameObject = getListContainingGameObject(gameObject);
        arrayListGameObject.remove(gameObject);
        arrayListGameObject.addFirst(gameObject);

        if (this.executeToFront)
            return;

        this.executeToFront = true;
        StartCoroutine(update());
    }

    private IEnumerator update()
    {
        yield return new WaitForFixedUpdate();
        execute();
    }

    private void execute()
    {
        this.executeToFront = false;

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

        return null;

    }

    public void addGameObject(SpriteView spriteView)
    {
        this.listLayerZ[spriteView.layerZ].addLast(spriteView.gameObject);
        this.listSpriteViews.Add(spriteView.gameObject, spriteView);
    }

}
