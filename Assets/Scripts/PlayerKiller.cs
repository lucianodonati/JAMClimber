using System.Collections;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Character>();
       GameManager.Instance.Lose(player.isP1);
        StartCoroutine(StopGameRoutine());
    }

    IEnumerator StopGameRoutine()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0.001f;
    }
}
