using System.Collections;
using UnityEngine;

public class ScopeMovement : MonoBehaviour
{
    public float speed = 1;

    public AnimationCurve toFinalVelocityCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public float          timeToFinalVelocity  = 1;
    public float          intialFinalHeight    = -2;

    private IEnumerator Start()
    {
        yield return StartCoroutine(ReachFinalVelocityRoutine());
        yield return new WaitForSeconds(3);
        StartCoroutine(ClimbRoutine());
    }

    private IEnumerator ReachFinalVelocityRoutine()
    {
        float timeElapsed      = 0;
        var   originalPosition = transform.position;

        do
        {
            var ratio = toFinalVelocityCurve.Evaluate(timeElapsed / timeToFinalVelocity);

            var finalY = Mathf.Lerp(originalPosition.y, intialFinalHeight, ratio);
            
            transform.position = new Vector3(
                originalPosition.x,
                finalY,
                originalPosition.z);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        } while (timeElapsed <= timeToFinalVelocity);

        transform.position = new Vector3(
            originalPosition.x,
            intialFinalHeight,
            originalPosition.z);
    }
    
    private IEnumerator ClimbRoutine()
    {
        do
        {
            transform.position += new Vector3(
                0,
                speed * Time.deltaTime,
                0);
            yield return null;
        } while (true);
    }
}
