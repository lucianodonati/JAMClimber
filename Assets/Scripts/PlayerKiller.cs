using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class PlayerKiller : MonoBehaviour
{
    public Text WinLose;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Character>();
        //WinLose.text   = $"Player {(player.isP1 ? "2" : "1")} WINS!";
        Time.timeScale = 0.001f;
    }
}
