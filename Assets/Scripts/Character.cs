using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    
    public float speed = 1;
    public float jumpForce = 1;


    private float currentX = 0;

    private void OnValidate()
    {
        if (null == rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(currentX, jumpForce), ForceMode2D.Impulse);
    }

    public void Move(float directionInX)
    {
        currentX = directionInX;
        
        transform.position += new Vector3(directionInX * speed * Time.deltaTime, 0 , 0);
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started) Jump();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        Move( value.ReadValue<float>());
    }
}
