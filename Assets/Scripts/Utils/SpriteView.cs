using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteView : MonoBehaviour
{

    public Sprite front, back;
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

            this.front = this.spriteRenderer.sprite;
            setBoxColliderSize();

        }
        else if (this.front != null)

        {
            this.spriteRenderer.sprite = this.front;
            setBoxColliderSize();

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

    public void setFront(string filePath)
    {
        this.front = Resources.Load<Sprite>(filePath);
        this.spriteRenderer.sprite = this.front;
        setBoxColliderSize();
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

    public void relocateTopLeft(float x, float y)
    {
        x += this.front.rect.width * this.gameObject.transform.localScale.x / 2;
        y -= this.front.rect.height * this.gameObject.transform.localScale.y / 2;
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

        float spriteWidth = this.front.rect.width;
        float scale = width / spriteWidth;

        this.gameObject.transform.localScale = new Vector2(scale, scale);
        setBoxColliderSize();

    }

    public void setHeight(float height)
    {

        float spriteHeight = this.front.rect.height;
        float scale = height / spriteHeight;

        this.gameObject.transform.localScale = new Vector2(scale, scale);
        setBoxColliderSize();

    }

    public float getWidth()
    {
        return this.boxCollider2D.size.x;
    }

    public float getHeight()
    {
        return this.boxCollider2D.size.y;
    }

    public Vector2 getDimensions()
    {
        return this.boxCollider2D.size;
    }

    public Vector2 getCoordinatesCenter()
    {
        return this.transform.position;
    }

    public Vector2 getCoordinatesTopLeft()
    {
        Vector2 coordinates = getCoordinatesCenter();
        coordinates.x -= getWidth() / 2;
        coordinates.y += getHeight() / 2;
        return coordinates;
    }

    public void setVisible(bool value)
    {
        this.gameObject.SetActive(value);
    }

    private void setBoxColliderSize()
    {

        float width = this.front.rect.width * this.gameObject.transform.localScale.x;
        float height = this.front.rect.height * this.gameObject.transform.localScale.y;

        this.boxCollider2D.size = new Vector2(width, height);
    }

    private void OnMouseDown()
    {

    }

}
