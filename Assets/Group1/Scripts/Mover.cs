using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private int _movementRadius = 4;
    [SerializeField] private float _speed = 4;

    private Vector2 _targetPosition;
    private Rigidbody2D _rigidbody2D;
 
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetPosition = GetNewTargetPosition();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        _rigidbody2D.position = Vector2.MoveTowards(_rigidbody2D.position, _targetPosition, _speed * Time.deltaTime);

        if (_rigidbody2D.position == _targetPosition)
        {
            _targetPosition = GetNewTargetPosition();
        }
    }

    private Vector3 GetNewTargetPosition()
    {
        return Random.insideUnitCircle * _movementRadius;
    }
}
