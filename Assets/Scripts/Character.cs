using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject dustPrefab;

    public float speed     = 1;
    public float jumpForce = 1;
    public bool  isP1;
    
    private float currentX = 0;

    private void OnValidate()
    {
        if (null == rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(currentX, jumpForce), ForceMode2D.Impulse);
        GameObject dust = Instantiate(dustPrefab);
        dust.transform.position = transform.position - new Vector3(0,0.5f);
    }

    private void Move(float directionInX)
    {
        currentX = directionInX;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(currentX * speed * Time.deltaTime, 0 , 0);
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started && IsGrounded()) Jump();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        Move( value.ReadValue<float>());
    }
    
    private bool IsGrounded() {
        var hit = Physics2D.RaycastAll(transform.position-new Vector3(0,0.75f), Vector2.down, 0.3f);
        foreach (var raycastHit2D in hit)
        {
            if (raycastHit2D.collider.gameObject.CompareTag("Platform")) return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isP1)
        {
            throw new NotImplementedException();
        }
    }
}
