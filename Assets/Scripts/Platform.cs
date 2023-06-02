using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool IsLeft;

    public Enemy enemy;

    private IEnumerator Start()
    {

        enemy = GetComponentInChildren<Enemy>();
        
        while (true)
        {
            if (Random.value < .4f)
            {
                enemy.PopIn(IsLeft);
                yield return new WaitForSeconds(4);
                enemy.PopOut();
                yield return new WaitForSeconds(4);
            }
            yield return new WaitForSeconds(4);
        }
    }
}
