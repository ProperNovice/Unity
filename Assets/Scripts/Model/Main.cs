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

        instantiateSprites();
        setUpSpriteLists();
        setUpTextCoordinates();
    }

    private void instantiateSprites()
    {

    }

    private void setUpSpriteLists()
    {

    }

    private void setUpTextCoordinates()
    {

    }

}
