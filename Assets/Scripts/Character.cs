using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    public void Jump()
    {
        
    }

    public void Move(Vector3 direction)
    {
        
    }
    
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started) Jump();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        float moveValue = value.ReadValue<float>();
        Vector3 direction = new Vector3(moveValue, 0f, 0f);
        Move(direction);
    }
}
