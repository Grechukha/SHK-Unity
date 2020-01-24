using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private Action _enemiesDied = null;

    public event Action EnemiesDied
    {
        add => _enemiesDied += value;
        remove => _enemiesDied -= value;
    }

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDead;
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Died += OnEnemyDead;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemy.Died -= OnEnemyDead;
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
