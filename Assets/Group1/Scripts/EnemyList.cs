using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    public event Action EnemiesDied;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.Died += OnEnemyDied;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            EnemiesDied?.Invoke();
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        RemoveEnemy(enemy);
    }
}
