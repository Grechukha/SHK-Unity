using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerationTime = 2;
    [SerializeField] private float _accelerationCoefficient = 2;

    private float _speedDownTime;
    private bool _isAccelerated;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
        if (_isAccelerated)
        {
            _speedDownTime -= Time.deltaTime;

            if (_speedDownTime < 0)
            {
                _isAccelerated = false;
                _speed /= _accelerationCoefficient;
            }
        }

        _horizontal = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        _vertical = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        _rigidbody2D.velocity = new Vector2(_horizontal, _vertical);
    }

    private void SpeedUp()
    {
        if (!_isAccelerated)
        {
            _speed *= _accelerationCoefficient;
            _isAccelerated = true;
            _speedDownTime = _accelerationTime;
        }
    }
}
