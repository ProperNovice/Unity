using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpriteSelect : MonoBehaviour
{

    public static ManagerSpriteSelect INSTANCE;
    public float percentageX = 50, percentageY = 50;
    public GameObject select;
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

    private void selectSprite(SpriteView spriteView)
    {

    }

    private void deselectSprite(SpriteView spriteView)
    {

    }

}
