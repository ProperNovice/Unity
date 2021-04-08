using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteView : MonoBehaviour
{

    public Sprite Front, Back;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {

        this.spriteRenderer = GetComponent<SpriteRenderer>();

        if (this.spriteRenderer.sprite != null)
        {

            this.Front = this.spriteRenderer.sprite;
            GetComponent<BoxCollider2D>().size = this.Front.rect.size;

        }
        else if (this.Front != null)

        {
            this.spriteRenderer.sprite = this.Front;
            GetComponent<BoxCollider2D>().size = this.Front.rect.size;

        }

    }

    public void flip()
    {

        if (this.spriteRenderer.sprite.Equals(this.Front))
            this.spriteRenderer.sprite = this.Back;
        else if (this.spriteRenderer.sprite.Equals(this.Back))
            this.spriteRenderer.sprite = this.Front;

    }

    public void flipFront()
    {
        this.spriteRenderer.sprite = this.Front;
    }

    public void flipBack()
    {
        this.spriteRenderer.sprite = this.Back;
    }

    private void OnMouseDown()
    {
        flip();
    }

    public void setFront(string filePath)
    {
        this.Front = Resources.Load<Sprite>(filePath);
        this.spriteRenderer.sprite = this.Front;
        GetComponent<BoxCollider2D>().size = this.Front.rect.size;
    }

    public void setBack(string filePath)
    {
        this.Back = Resources.Load<Sprite>(filePath);
    }

    public void setFrontBack(string filePathFront, string filePathBack)
    {
        setFront(filePathFront);
        setBack(filePathBack);
    }

    public void relocateTopLeft(float x, float y)
    {
        x += this.Front.rect.width / 2;
        y -= this.Front.rect.height / 2;
        relocateCenter(x, y);
    }

    public void relocateCenter(float x, float y)
    {
        this.transform.localPosition = new Vector2(x, y);
    }

    public void a()
    {
        Destroy(GetComponent<BoxCollider2D>());
        this.gameObject.AddComponent<BoxCollider2D>();
    }

}
