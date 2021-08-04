using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

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
        _rigidbody.velocity = new Vector2(rawInputMovement.normalized.x * speed, _rigidbody.velocity.y);
    }

    public void onMovement(InputAction.CallbackContext value) {
        inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector2(inputMovement.x, 0f);
    }
}
