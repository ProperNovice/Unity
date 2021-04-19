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

    private void Awake()
    {
        this.textMesh = GetComponent<TextMesh>();
        this.gameObjectChildSpriteRenderer = this.gameObjectChild.GetComponent<SpriteRenderer>();
    }

    public void setText(EText eText)
    {

        this.eText = eText;
        this.textMesh.text = this.eText.text;

        if (!this.eText.isTextOption)
            return;

        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();

        this.gameObjectChildSpriteRenderer.transform.localPosition = boxCollider.offset;
        this.gameObjectChildSpriteRenderer.transform.localScale = boxCollider.size;

        OnMouseExit();

    }

    public void relocate(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    public void setActive(bool value)
    {
        this.gameObject.SetActive(value);
        // this.gameObjectChild.SetActive(value);
    }

    public void OnMouseEnter()
    {

        this.textMesh.color = white;
        this.gameObjectChildSpriteRenderer.color = black;

    }

    public void OnMouseExit()
    {

        this.textMesh.color = black;
        this.gameObjectChildSpriteRenderer.color = wheat;

    }

    private void OnMouseDown()
    {
        setActive(false);
    }

}
