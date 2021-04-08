using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteView : MonoBehaviour
{

    public Sprite front, back;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {

        this.spriteRenderer = GetComponent<SpriteRenderer>();

        if (this.spriteRenderer.sprite != null)
        {

            this.front = this.spriteRenderer.sprite;
            this.gameObject.AddComponent<BoxCollider2D>();

        }
        else if (this.front != null)

        {
            this.spriteRenderer.sprite = this.front;
            this.gameObject.AddComponent<BoxCollider2D>();

        }

    }

    public void flip()
    {

        if (this.spriteRenderer.sprite.Equals(this.front))
            this.spriteRenderer.sprite = this.back;
        else if (this.spriteRenderer.sprite.Equals(this.back))
            this.spriteRenderer.sprite = this.front;

    }

    public void flipFront()
    {
        this.spriteRenderer.sprite = this.front;
    }

    public void flipBack()
    {
        this.spriteRenderer.sprite = this.back;
    }

    private void OnMouseDown()
    {
        flip();
    }

    public void setFront(string filePath)
    {
        this.front = Resources.Load<Sprite>(filePath);
        this.spriteRenderer.sprite = this.front;
        this.gameObject.AddComponent<BoxCollider2D>();
    }

    public void setBack(string filePath)
    {
        this.back = Resources.Load<Sprite>(filePath);
    }

    public void setFrontBack(string filePathFront, string filePathBack)
    {
        setFront(filePathFront);
        setBack(filePathBack);
    }

}
