using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private UnityEvent _enemiesDied = new UnityEvent();

    public event UnityAction EnemiesDied
    {
        add => _enemiesDied.AddListener(value);
        remove => _enemiesDied.RemoveListener(value);
    }

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dead += OnEnemyDead;
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Dead += OnEnemyDead;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemy.Dead -= OnEnemyDead;
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            _enemiesDied?.Invoke();
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        RemoveEnemy(enemy);
    }
}
