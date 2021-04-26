using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObjectPool : MonoBehaviour
{

    public static ManagerObjectPool INSTANCE;
    private Dictionary<GameObject, ArrayList<GameObject>> list;

    private void Awake()
    {
        INSTANCE = this;
        this.list = new Dictionary<GameObject, ArrayList<GameObject>>();
    }

    public GameObject getGameObject(GameObject prefab)
    {

        handleListEntry(prefab);

        foreach (GameObject gameObject in this.list[prefab])
        {

            if (gameObject.activeInHierarchy)
                continue;

            gameObject.SetActive(true);
            return gameObject;

        }

        GameObject gameObjectNewInstance = Instantiate(prefab);
        this.list[prefab].addLast(gameObjectNewInstance);

        return gameObjectNewInstance;

    }

    private void handleListEntry(GameObject prefab)
    {

        if (this.list.ContainsKey(prefab))
            return;

        this.list.Add(prefab, new ArrayList<GameObject>());

    }

}
