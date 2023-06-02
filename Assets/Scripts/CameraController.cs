using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  Transform player1, player2;

    public float offset = 10;
    public float damp = .4f;
    
    private Vector3 speed = Vector3.zero;
    private Vector3 initialPosition;
    private float   height = 0;

    private void Start()
    {
        initialPosition = transform.position;   
    }

    private void Update()
    {
        height =  Mathf.Max(player1.position.y, player2.position.y) - initialPosition.y;

        var verticalHeight = initialPosition.y + height + offset * Time.smoothDeltaTime;

        var newPosition = new Vector3(initialPosition.x, verticalHeight, initialPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref speed, damp);
    }
    
}
