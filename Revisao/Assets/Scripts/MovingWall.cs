using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody _rb;
    
    bool _canMove;

    private void Awake()
    {
        StartCoroutine(Movement());
    }

    private void Start()
    {
        _rb =  GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rb.linearVelocity = Vector3.left * (moveSpeed * 100 * Time.deltaTime);
        }
        else
        {
            _rb.linearVelocity = Vector3.zero;
        }
    }

    private IEnumerator Movement()
    {
        _canMove = true;
        yield return new WaitForSeconds(2f);
        _canMove = false;
        yield return new WaitForSeconds(3f);
        moveSpeed *= -1;
        
        StartCoroutine(Movement());
    }
}
