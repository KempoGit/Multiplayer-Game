using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private bool _isGrounded;

    private Vector2 inputMovement;
    private Vector2 rawInputMovement;

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        _rigidbody.velocity = new Vector2(rawInputMovement.normalized.x * speed, _rigidbody.velocity.y);
    }

    public void onMovement(InputAction.CallbackContext value) {
        inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector2(inputMovement.x, 0f);
    }

    public void onJump(InputAction.CallbackContext value)
    {
        if (value.started && _isGrounded == true)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
