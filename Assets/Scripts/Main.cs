using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject prefabSprite;
    private Vector2 screenResolution;

    void Start()
    {
        this.screenResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);

        // instantiates();
        spriteLists();

    }

    private void instantiates()
    {

        for (int counter = 1; counter <= 10; counter++)
        {
            GameObject gameObject = Instantiate(this.prefabSprite);
            SpriteView spriteView = gameObject.GetComponent<SpriteView>();
            spriteView.setFront("Misc/SelectBlackWhite");
            spriteView.setWidth(100);
            ManagerSpriteList.INSTANCE.list[EList.DECK].arrayList.addLast(gameObject);
        }

    }

    private void spriteLists()
    {
        SpriteList spriteList = ManagerSpriteList.INSTANCE.list[EList.DECK];
        spriteList.objectsPerRow = 4;
        spriteList.relocateSprites();
    }

}
