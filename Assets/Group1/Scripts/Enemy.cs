using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    private void OnDestroy()
    {
        Died?.Invoke(this);
    }
}
