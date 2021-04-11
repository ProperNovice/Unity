using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteView : MonoBehaviour
{

    public Sprite Front, Back;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    void Awake()
    {

        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {

        if (this.spriteRenderer.sprite != null)
        {

            this.Front = this.spriteRenderer.sprite;
            setBoxColliderSize();

        }
        else if (this.Front != null)

        {
            this.spriteRenderer.sprite = this.Front;
            setBoxColliderSize();

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

    public void setFront(string filePath)
    {
        this.Front = Resources.Load<Sprite>(filePath);
        this.spriteRenderer.sprite = this.Front;
        setBoxColliderSize();
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
        x += this.Front.rect.width * this.gameObject.transform.localScale.x / 2;
        y -= this.Front.rect.height * this.gameObject.transform.localScale.y / 2;
        relocateCenter(x, y);
    }

    public void relocateTopLeft(Vector2 vector2)
    {
        relocateTopLeft(vector2.x, vector2.y);
    }

    public void relocateCenter(float x, float y)
    {
        this.transform.localPosition = new Vector2(x, y);
    }

    public void relocateCenter(Vector2 vector2)
    {
        relocateCenter(vector2.x, vector2.y);
    }

    public void setWidth(float width)
    {

        float spriteWidth = this.Front.rect.width;
        float scale = width / spriteWidth;

        this.gameObject.transform.localScale = new Vector2(scale, scale);
        setBoxColliderSize();

    }

    public void setHeight(float height)
    {

        float spriteHeight = this.Front.rect.height;
        float scale = height / spriteHeight;

        this.gameObject.transform.localScale = new Vector2(scale, scale);
        setBoxColliderSize();

    }

    private void setBoxColliderSize()
    {

        float width = this.Front.rect.width * this.gameObject.transform.localScale.x;
        float height = this.Front.rect.height * this.gameObject.transform.localScale.y;

        this.boxCollider2D.size = new Vector2(width, height);
    }

    private void OnMouseDown()
    {

    }

}
