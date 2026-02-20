using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed, jumpForce;
    InputControls inputControls;
    bool canJump;
    bool jumping;
    InputAction jump;
    private Vector2 InputDirection => inputControls.Player.Move.ReadValue<Vector2>();

    private void Awake()
    {
        inputControls = new InputControls();
        inputControls.Enable();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        jump = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        float moveX = InputDirection.x * moveSpeed * Time.deltaTime;
        float moveZ = InputDirection.y * moveSpeed * Time.deltaTime;
        
        transform.Translate(moveX, 0 ,moveZ);

        if (jump.WasPressedThisFrame() && canJump)
        {
            jumping = true;
            canJump = false;
        }
    }
    private void FixedUpdate()
    {
        if (jumping)
        {
            Debug.Log("eita preula");
            rb.AddForce(new(0, jumpForce, 0), ForceMode.Impulse);
            jumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnDestroy()
    {
        inputControls.Disable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
}
