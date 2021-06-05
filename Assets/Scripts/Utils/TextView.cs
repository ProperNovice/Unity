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

    public void setEText(EText eText)
    {

        this.eText = eText;
        setText(this.eText.text);

        if (!this.eText.isTextOption)
            return;

        this.gameObjectChildSpriteRenderer.transform.localPosition = this.boxCollider2D.offset;
        this.gameObjectChildSpriteRenderer.transform.localScale = this.boxCollider2D.size;

        OnMouseExit();

    }

    public void setText(string text)
    {
        this.textMesh.text = text;
        this.boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
    }

    public void relocateTopLeft(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    public void relocateCenterX(float x, float y)
    {
        float width = getDimensions().x;
        relocateTopLeft(x - width / 2, y);
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

        if (!hasEventHandler())
            return;

        this.textMesh.color = white;
        this.gameObjectChildSpriteRenderer.color = black;

    }

    public void OnMouseExit()
    {

        if (!hasEventHandler())
            return;

        this.textMesh.color = black;
        this.gameObjectChildSpriteRenderer.color = wheat;

    }

    private void OnMouseDown()
    {

        if (!hasEventHandler())
            return;

        ManagerFlow.INSTANCE.gameStateCurrent.notifyTextOptionPressed(this.eText);

    }

    private bool hasEventHandler()
    {
        if (this.eText == null)
            return false;

        if (!this.eText.isTextOption)
            return false;

        return true;
    }

}
