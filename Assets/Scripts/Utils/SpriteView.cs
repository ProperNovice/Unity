using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteView : MonoBehaviour
{

    [SerializeField] private Sprite front, back;
    public ELayerZ layerZ = ELayerZ.DEFAULT;
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

        ManagerSpriteView.INSTANCE.list.Add(this.gameObject, this);
        ManagerLayerZ.INSTANCE.list[this.layerZ].addLast(this.gameObject);
        this.gameObject.transform.parent = ManagerSpriteView.INSTANCE.parent.transform;

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
        this.transform.localPosition = new Vector2(x, y);
    }

    public void relocateTopLeft(Vector2 vector2)
    {
        relocateTopLeft(vector2.x, vector2.y);
    }

    public void relocateCenter(float x, float y)
    {
        x -= this.front.rect.width * this.transform.localScale.x / 2;
        y += this.front.rect.height * this.transform.localScale.y / 2;
        relocateTopLeft(x, y);
    }

    public void relocateCenter(Vector2 vector2)
    {
        relocateCenter(vector2.x, vector2.y);
    }

    public void setWidth(float width)
    {

        float spriteWidth = this.front.rect.width;
        float scale = width / spriteWidth;

        this.transform.localScale = new Vector2(scale, scale);
        setBoxColliderSize();

    }

    public void setHeight(float height)
    {

        float spriteHeight = this.front.rect.height;
        float scale = height / spriteHeight;

        this.transform.localScale = new Vector2(scale, scale);
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

        Vector2 coordinates = getCoordinatesTopLeft();
        coordinates.x += getWidth() / 2;
        coordinates.y -= getHeight() / 2;
        return coordinates;

    }

    public Vector2 getCoordinatesTopLeft()
    {
        return this.transform.position;
    }

    public void setVisible(bool value)
    {
        this.gameObject.SetActive(value);
    }

    private void setBoxColliderSize()
    {

        float width = this.front.rect.width * this.transform.localScale.x;
        float height = this.front.rect.height * this.transform.localScale.y;
        this.boxCollider2D.size = new Vector2(width, height);

        float offsetX = width / 2;
        float offsetY = -height / 2;
        this.boxCollider2D.offset = new Vector2(offsetX, offsetY);

    }

    public void setActive(bool value)
    {
        this.gameObject.SetActive(value);
    }

    public void setSortingOrder(int sortingOrder)
    {
        this.spriteRenderer.sortingOrder = sortingOrder;
    }

    private void OnMouseDown()
    {

    }

}
