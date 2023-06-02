using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;

    public Vector2 PopOutEveryRange = new Vector2(1, 10);
    public Vector2 StayOutRange = new Vector2(1, 5);

    public float timeToComeOut = 1;
    
    public float offsetX = 1;
    
    private bool isLeft = true;
    
    [SerializeField]
    private SpriteRenderer sr;
    
    [SerializeField]
    private Collider2D col;

    private void OnValidate()
    {
        if (null == sr)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        if (null == col)
        {
            col = GetComponent<Collider2D>();
        }
    }

    public void PopIn(bool left)
    {
        col.enabled = true;
        isLeft      = left;
        sr.enabled  = true;
        sr.sprite = isLeft
            ? leftSprites[Random.Range(0,  leftSprites.Length)]
            : rightSprites[Random.Range(0, rightSprites.Length)];
    }
    
    public void PopOut()
    {
        col.enabled = false;
        sr.enabled  = false;
    }

}
