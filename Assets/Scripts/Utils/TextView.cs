using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextView : MonoBehaviour
{

    private TextMesh textMesh;
    public GameObject gameObjectChild;
    private SpriteRenderer gameObjectChildSpriteRenderer;
    public EText eText;
    public Color black, white, wheat;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        this.textMesh = GetComponent<TextMesh>();
        this.gameObjectChildSpriteRenderer = this.gameObjectChild.GetComponent<SpriteRenderer>();
    }

    public void setText(EText eText)
    {

        this.eText = eText;
        this.textMesh.text = this.eText.text;

        this.boxCollider2D = gameObject.AddComponent<BoxCollider2D>();

        if (!this.eText.isTextOption)
            return;

        this.gameObjectChildSpriteRenderer.transform.localPosition = this.boxCollider2D.offset;
        this.gameObjectChildSpriteRenderer.transform.localScale = this.boxCollider2D.size;

        OnMouseExit();

    }

    public void relocate(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    public Vector2 getDimensions()
    {
        return this.boxCollider2D.size;
    }

    public void setActive(bool value)
    {
        this.gameObject.SetActive(value);
        OnMouseExit();
    }

    public void OnMouseEnter()
    {

        if (!this.eText.isTextOption)
            return;

        this.textMesh.color = white;
        this.gameObjectChildSpriteRenderer.color = black;

    }

    public void OnMouseExit()
    {

        if (!this.eText.isTextOption)
            return;

        this.textMesh.color = black;
        this.gameObjectChildSpriteRenderer.color = wheat;

    }

    private void OnMouseDown()
    {

        if (!this.eText.isTextOption)
            return;

        ManagerFlow.INSTANCE.gameStateCurrent.notifyTextOptionPressed(this.eText);

    }

}
