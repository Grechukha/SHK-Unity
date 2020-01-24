﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerationTime = 2;
    [SerializeField] private float _accelerationCoefficient = 2;

    private Rigidbody2D _rigidbody2D;
    private float _originalSpeed;
    private float _speedDownTime;
    private bool _isAccelerated;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _originalSpeed = _speed;
    }

    private void Update()
    {
        CheckTimer();
        Move();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<Accelerator>())
        {
            SpeedUp();
            Destroy(collision.gameObject);
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = GetCurrentSpeed();
    }

    private Vector2 GetCurrentSpeed()
    {
        float _horizontalSpeed = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        float _verticalSpeed = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        return new Vector2(_horizontalSpeed, _verticalSpeed);
    }

    private void CheckTimer()
    {
        if (_isAccelerated)
        {
            _speedDownTime -= Time.deltaTime;

            if (_speedDownTime < 0)
            {
                SpeedDown();
            }
        }
    }

    private void SpeedUp()
    {
        _speed *= _accelerationCoefficient;
        _isAccelerated = true;
        _speedDownTime = _accelerationTime;
    }

    private void SpeedDown()
    {
        _isAccelerated = false;
        _speed = _originalSpeed;
    }
}
