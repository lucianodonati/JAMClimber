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

    private void OnValidate()
    {
        if (null == sr)
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }

    public void PopOut(bool left)
    {
        isLeft = left;
        StartCoroutine(PopOutRoutine());
    }

    private IEnumerator PopOutRoutine()
    {
        sr.sprite = isLeft
            ? leftSprites[Random.Range(0,  leftSprites.Length)]
            : rightSprites[Random.Range(0, rightSprites.Length)];

        sr.enabled = true;
        
        yield return new WaitForSeconds(Random.Range(PopOutEveryRange.x, PopOutEveryRange.y));

        float timeElapsed = 0;

        var start = new Vector3(
            transform.position.x + (isLeft ? 1 : -1) * offsetX,
            transform.position.y,
            transform.position.z);
        var end = new Vector3(
            start.x + (isLeft ? 1 : -1) * offsetX,
            start.y,
            start.z);

        do
        {
            transform.localPosition =  Vector3.Lerp(start, end, timeElapsed / timeToComeOut);
            timeElapsed             += Time.deltaTime;
        } while (timeElapsed <= timeToComeOut);

        yield return new WaitForSeconds(Random.Range(StayOutRange.x, StayOutRange.y));

        start = transform.localPosition;
        end = new Vector3(
            start.x + (isLeft ? -1 : 1) * offsetX,
            start.y,
            start.z);

        do
        {
            transform.localPosition =  Vector3.Lerp(start, end, timeElapsed / timeToComeOut);
            timeElapsed             += Time.deltaTime;
        } while (timeElapsed <= timeToComeOut);
    }
}
