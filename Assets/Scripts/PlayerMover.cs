using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _score;

    private bool _grounded;

    public int Score => _score;
    
    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var mouseY = Input.GetAxis("Mouse X");
        
        transform.Rotate(0f, mouseY, 0f);
        
        var verticalSpeed = vertical * _speed * Time.deltaTime;
        
        _rigidbody.AddRelativeForce(0f, 0f, verticalSpeed, ForceMode.Impulse);
        
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
            _rigidbody.AddRelativeForce(0f, _jumpForce, 0f, ForceMode.Force);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground)) 
            _grounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground)) 
            _grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _score++;
        }
    }
}
