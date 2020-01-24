using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Action<Enemy> _died = null;

    public event Action<Enemy> Died
    {
        add => _died += value;
        remove => _died -= value;
    }

    private void OnDestroy()
    {
        _died?.Invoke(this);
    }
}
