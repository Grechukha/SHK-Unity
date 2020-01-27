using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died = null;

    private void OnDestroy()
    {
        Died?.Invoke(this);
    }
}
