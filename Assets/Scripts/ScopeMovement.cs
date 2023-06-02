using System.Collections;
using UnityEngine;

public class ScopeMovement : MonoBehaviour
{
    public float speed = 5;

    public AnimationCurve toFinalVelocityCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public float          timeToFinalVelocity  = 1;
    public float          intialFinalHeight    = 3;

    private IEnumerator Start()
    {
        yield return StartCoroutine(ReachFinalVelocityRoutine());
        StartCoroutine(ClimbRoutine());
    }

    private IEnumerator ReachFinalVelocityRoutine()
    {
        float timeElapsed      = 0;
        var   originalPosition = transform.position;

        do
        {
            var ratio = toFinalVelocityCurve.Evaluate(timeElapsed);
            
            transform.position = new Vector3(
                originalPosition.x, 
                originalPosition.y + ratio * intialFinalHeight,
                originalPosition.z);
            
            timeElapsed += Time.smoothDeltaTime;
            yield return null;
        } while (timeElapsed <= timeToFinalVelocity);
        
        transform.position = new Vector3(
            originalPosition.x, 
            originalPosition.y + intialFinalHeight,
            originalPosition.z);
    }
    
    private IEnumerator ClimbRoutine()
    {
        var   originalPosition = transform.position;

        do
        {
            transform.position = new Vector3(
                originalPosition.x, 
                originalPosition.y + intialFinalHeight + speed * Time.smoothDeltaTime,
                originalPosition.z);
            yield return null;
        } while (true);
    }
}
