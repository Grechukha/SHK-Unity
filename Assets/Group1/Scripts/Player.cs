using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerationTime = 2;
    [SerializeField] private float _accelerationCoefficient = 2;

    private Rigidbody2D _rigidbody2D;

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
        _rigidbody2D.velocity = GetCurrentSpeed();
    }

    private Vector2 GetCurrentSpeed()
    {
        return new Vector2(GetAxisSpeed("Horizontal"), GetAxisSpeed("Vertical"));
    }

    private float GetAxisSpeed(string axisName)
    {
        return Input.GetAxisRaw(axisName) * _speed * Time.deltaTime;
    }


    private void SpeedUp()
    {
        _speed *= _accelerationCoefficient;

        StartCoroutine(SpeedDown());
    }

    private IEnumerator SpeedDown()
    {
        yield return new WaitForSeconds(_accelerationTime);

        _speed /= _accelerationCoefficient;
    }
}
