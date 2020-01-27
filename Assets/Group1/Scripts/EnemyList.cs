using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    public Action EnemiesDied = null;

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDead;
        }
    }

    private void OnDestroy()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDead;
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
            EnemiesDied?.Invoke();
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        RemoveEnemy(enemy);
    }
}
