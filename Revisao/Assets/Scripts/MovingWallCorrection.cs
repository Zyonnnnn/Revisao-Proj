using System;
using UnityEngine;

public class MovingWallCorrection : MonoBehaviour
{
    [SerializeField] private Vector3 distanceOffset;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;
    
    Vector3 startPosition;
    
    private float elapsedTime = 0;
    private bool _canMove = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    { 
        HandleMovement();
        CheckDistance();
        HandleTimer();
        CheckTimer();
    }
    
    private void HandleMovement()
    {
        if (_canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + distanceOffset, moveSpeed * Time.deltaTime);
        }
    }
    private void CheckDistance()
    {
        if (Vector3.Distance(transform.position, startPosition + distanceOffset) <= 0.1f)
        {
            _canMove = false;
        }
    }
    
    private void HandleTimer()
    {
        if (elapsedTime >= waitTime)
        {
            elapsedTime = 0;
            _canMove = true;
            distanceOffset *= -1;
        }
    }
    private void CheckTimer()
    {
        if (!_canMove)
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
