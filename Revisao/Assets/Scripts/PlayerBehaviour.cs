using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    InputControls inputControls;
    private Vector2 inputDirection => inputControls.Player.Move.ReadValue<Vector2>();

    private void Awake()
    {
        inputControls = new InputControls();
        inputControls.Enable();
    }

    private void Update()
    {
        float moveX = inputDirection.x * moveSpeed * Time.deltaTime;
        float moveZ = inputDirection.y * moveSpeed * Time.deltaTime;
        
        transform.Translate(moveX, 0 ,moveZ);
    }

    private void OnCollisionEnter(Collision other)
    {
        print("porra");
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
